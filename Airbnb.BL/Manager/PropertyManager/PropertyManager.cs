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
            MaxNumOfGuest = property.MaximumNumberOfGuests,
            BedRoomCount = property.BedCount,
            BathRoomCount = property.BathroomCount,
            PricePerNight = property.PricePerNight,
            PropertyDescription = property.Description,
            CityNmae = property.City?.CityName ?? string.Empty,
            CountryNmae = property.City?.Country?.CountryName ?? string.Empty,
            UserName = $"{property.User?.FirstName ?? string.Empty} {property.User?.LasttName ?? string.Empty}",
            RatingOverroll = property.OverALLReview,
            NumOfReview = property.NumberOfReview,
            Aminties = property.PropertyAmenities.Select(a => new AmintsDTO
            {
                AmintiesName = a.Amenity?.Name ?? string.Empty,
                Icon = a.Amenity?.Icon ?? string.Empty
            }),
            Imgs = property.PropertyImages.Select(x => x.Image),
            UserImage = property.User?.UserImage ?? string.Empty,
            BookingDates = property.PropertyBookings.Select(x => new PropertyBookingDates { CheckInDate = x.CheckInDate, CheckOutDate = x.CheckOutDate }),
            Reviews = property.Reviews.Select(x => new Reviewdto { Rate = x.Rate, ReviewComment = x.Comment, CreateDate=x.CreatedDate, UserName= x.User.FirstName+' '+x.User.LasttName, Userimage = x.User.UserImage  })
        };

    }



    public bool AddBooking(AddBookingDto bookingDto, string userId)
    {

        Property? property = _propertyRepo.FindPropertyById(bookingDto.PropertyId);
        if (property == null || property.UserId == userId || property.MaximumNumberOfGuests < bookingDto.NumOfGuest)
        {
            return false;
        }
        Booking booking = new Booking
        {
            Id = Guid.NewGuid(),
            UserId = userId,
            PropertyId = bookingDto.PropertyId,
            CheckInDate = bookingDto.StartDate,
            CheckOutDate = bookingDto.EndDate,
            NumberOfGuests = bookingDto.NumOfGuest,
            TotalPrice = property.PricePerNight * (bookingDto.EndDate - bookingDto.StartDate).TotalDays,
            BookingDate = DateTime.Now
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

    public checkforReviewDto checkforreview(Guid propertyid, string userid)
    {
        var bookings = _propertyRepo.GetBookingsByPropertyId(propertyid);
        bookings = bookings.Where(x => x.CheckInDate <= DateTime.Now && x.is_revied == false && x.UserId  ==userid).OrderBy(x =>x.CheckInDate).ToList();

        if (bookings.Count() == 0 || bookings==null)
        {
            return new checkforReviewDto { hasreview = false, bookingid = null };

        } else if (bookings.Count() == 1)
        {

            return new checkforReviewDto { hasreview = true, bookingid = bookings.Select(x=>x.Id).FirstOrDefault() };


        }else if (bookings.Count() > 1)
        {
            var last = bookings.Last();
            foreach(var book in bookings)
{
                // do something with each item
                if (book.Equals(last))
                {
                    return new checkforReviewDto { hasreview = true, bookingid = book.Id };
                }
                else
                {
                    book.is_revied = true;
                }
            }
        }


        return new checkforReviewDto { bookingid = null, hasreview = false };
        



    }


}
