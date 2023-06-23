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
    public void Add(Booking booking)
    {
        _Context.Set<Booking>().Add(booking);
    }

    public int SaveChanges()
    {
        return _Context.SaveChanges();
    }

    public IEnumerable<Booking> GetBookingsByPropertyId(Guid propertyId)
    {
        IEnumerable<Booking> bookings = _Context.Bookings
       .Where(booking => booking.PropertyId == propertyId)
       .ToList();
        return bookings;
    }
}
