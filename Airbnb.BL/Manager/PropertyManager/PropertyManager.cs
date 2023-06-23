using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Airbnb.DAL;

namespace Airbnb.BL;

public class PropertyManager : IPropertyManager
{
    private readonly IPropertyDetailsRepo _propertyRepo;
    public PropertyManager(IPropertyDetailsRepo propertyRepo)
    {
        _propertyRepo = propertyRepo;
    }
    public GetPropertyDetailsDto? FindPropertyById(Guid propertyId)
    {
        Property? property = _propertyRepo.FindPropertyById(propertyId);
        if (property == null)
        {
            return null;
        }
        return new GetPropertyDetailsDto
        {
            NameOfProperty = property.Name,
            MaxNumOfGust = property.MaximumNumberOfGuests,
            BedRoomCount = property.BedCount,
            PricePerNight = property.PricePerNight,
            PropertyDescription = property.Description,
            CityNmae = property.City?.CityName ?? string.Empty,
            CountryNmae = property.City?.Country?.CountryName ?? string.Empty,
            UserName = $"{property.User?.FirstName ?? string.Empty} {property.User?.LasttName ?? string.Empty}",
            RatingOverroll = property.Reviews.Select(x => x.Rate).Average().ToString(),
            NumOfReview = property.Reviews.Count(),
            Aminties = property.PropertyAmenities.Select(a => new AmintsDTO
            {
                AmintiesName = a.Amenity?.Name ?? string.Empty,
                Icon = a.Amenity?.Icon ?? string.Empty
            }).ToList(),
            Imgs = property.PropertyImages.Select(x => x.Image).ToList(),
            UserImage = "image not working yet"

        };

    }

    //public IEnumerable<BookingDto> GetBookingsByPropertyId(Guid propertyId)
    //{
    //    IEnumerable<Booking> bookings = _propertyRepo.GetBookingsByPropertyId(propertyId);
    //    // Map bookings to BookingDto objects
    //    IEnumerable<BookingDto> bookingDtos = bookings.Select(booking => new BookingDto
    //    {
    //        CheckInDate = booking.CheckInDate,
    //        CheckOutDate = booking.CheckOutDate
    //    });

    //    return bookingDtos;
    //}


    public bool AddBooking(AddBookingDto bookingDto)
    {
        Property? property = _propertyRepo.FindPropertyById(bookingDto.PropertyId);
        if (property == null)
        {
            return false;
        }

        Booking booking = new Booking
        {
            Id = Guid.NewGuid(),
            UserId = bookingDto.UserId,
            PropertyId = bookingDto.PropertyId,
            CheckInDate = bookingDto.StartDate,
            CheckOutDate = bookingDto.EndDate,
            NumberOfGuests = bookingDto.NumOfGuest,
            TotalPrice = property.PricePerNight * (bookingDto.EndDate - bookingDto.StartDate).TotalDays,
        };

        bool isAdded = _propertyRepo.Add(booking);
        if (isAdded)
        {
            _propertyRepo.SaveChanges();
            return true;
        }
        else
        {
            return false;
        }
    }


}
