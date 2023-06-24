using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using Airbnb.DAL.Data;
using Microsoft.EntityFrameworkCore;

namespace Airbnb.DAL;

public class PropertyDetailsRepo : IPropertyDetailsRepo
{
    private readonly AircbnbContext _Context;
    public PropertyDetailsRepo(AircbnbContext Context)
    {
        _Context = Context;
    }



    public Property? FindPropertyById(Guid id)
    {
        return _Context.Set<Property>()
            .Include(x => x.PropertyImages)
            .Include(u => u.User)
            .Include(c => c.City).ThenInclude(c => c.Country)
            .Include(x => x.Reviews)
            .Include(x => x.PropertyAmenities)
            .ThenInclude(x => x.Amenity)
            .FirstOrDefault(x => x.Id == id);
    }

    public bool Add(Booking booking)
    {
        if (IsBookingDateRangeOverlap(booking))
        {
            return false; // Return false if there is a date range overlap
        }

        _Context.Set<Booking>().Add(booking);
        _Context.SaveChanges();
        return true;
    }

    public IEnumerable<Booking> GetBookingsByPropertyId(Guid propertyId)
    {
        IEnumerable<Booking> bookings = _Context.Bookings
       .Where(booking => booking.PropertyId == propertyId)
       .ToList();
        return bookings;
    }


    //public bool IsBookingDateRangeOverlap(Booking newBooking)
    //{
    //    IEnumerable<Booking> propertyBookings = GetBookingsByPropertyId((Guid)newBooking.PropertyId);

    //    return propertyBookings.Any(existingBooking =>
    //        (newBooking.CheckInDate < existingBooking.CheckOutDate && newBooking.CheckOutDate > existingBooking.CheckInDate) ||
    //        (newBooking.CheckInDate < existingBooking.CheckInDate && newBooking.CheckOutDate > existingBooking.CheckInDate) ||
    //        (newBooking.CheckInDate < existingBooking.CheckOutDate && newBooking.CheckOutDate > existingBooking.CheckOutDate) 
    //    );
    //}
    public bool IsBookingDateRangeOverlap(Booking newBooking)
    {
        IEnumerable<Booking> propertyBookings = GetBookingsByPropertyId((Guid)newBooking.PropertyId);
        DateTime newBookingCheckInDate = newBooking.CheckInDate;
        DateTime newBookingCheckOutDate = newBooking.CheckOutDate;

        return propertyBookings.Any(existingBooking =>
            (newBookingCheckInDate < existingBooking.CheckOutDate && newBookingCheckOutDate > existingBooking.CheckInDate) ||
            (newBookingCheckInDate < existingBooking.CheckInDate && newBookingCheckOutDate > existingBooking.CheckInDate) ||
            (newBookingCheckInDate < existingBooking.CheckOutDate && newBookingCheckOutDate > existingBooking.CheckOutDate) ||
            (newBookingCheckInDate <= existingBooking.CheckInDate && newBookingCheckOutDate >= existingBooking.CheckOutDate) ||
            (newBookingCheckInDate >= existingBooking.CheckInDate && newBookingCheckOutDate <= existingBooking.CheckOutDate) ||
            (newBookingCheckInDate <= existingBooking.CheckInDate && newBookingCheckOutDate >= existingBooking.CheckInDate) ||
            (newBookingCheckInDate <= existingBooking.CheckOutDate && newBookingCheckOutDate >= existingBooking.CheckOutDate)
        ) ||
        propertyBookings.Any(existingBooking =>
            (newBookingCheckInDate >= existingBooking.CheckInDate && newBookingCheckOutDate <= existingBooking.CheckOutDate) ||
            (newBookingCheckInDate <= existingBooking.CheckInDate && newBookingCheckOutDate >= existingBooking.CheckOutDate) ||
            (newBookingCheckInDate <= existingBooking.CheckInDate && newBookingCheckOutDate >= existingBooking.CheckInDate) ||
            (newBookingCheckInDate >= existingBooking.CheckInDate && newBookingCheckOutDate <= existingBooking.CheckInDate) ||
            (newBookingCheckInDate >= existingBooking.CheckOutDate && newBookingCheckOutDate <= existingBooking.CheckOutDate)
        ) ||
        propertyBookings.Any(existingBooking =>
            (newBookingCheckInDate >= existingBooking.CheckInDate && newBookingCheckInDate < existingBooking.CheckOutDate) ||
            (newBookingCheckOutDate > existingBooking.CheckInDate && newBookingCheckOutDate <= existingBooking.CheckOutDate)
        ) &&
        newBookingCheckOutDate > newBookingCheckInDate; // Check if check-out date is after check-in date
    }


    public int SaveChanges()
    {
        return _Context.SaveChanges();
    }
}
