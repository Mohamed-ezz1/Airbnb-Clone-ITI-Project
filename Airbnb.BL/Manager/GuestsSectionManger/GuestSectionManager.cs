using Airbnb.BL;
using Airbnb.DAl;
using Airbnb.DAL.Repositories.GuestsSectionRepo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Airbnb.BL;

public class GuestSectionManager : IGuestSectionManager
{
    private readonly IGuestSectionRepo _IGuestSectionRepo;

    public GuestSectionManager(IGuestSectionRepo GuestSectionRepo)
    {
        _IGuestSectionRepo = GuestSectionRepo;
    }


    public GuestBookingsHistory? GetGuestBooking(Guid bookTd)
    {
        Booking Booking = _IGuestSectionRepo.GetGuestBooking(bookTd);

        return new GuestBookingsHistory
        {
            HostName = Booking.User.FirstName,
            BookId = Booking.Id,
            CheckInDate = Booking.CheckInDate,
            CheckOutDate = Booking.CheckOutDate,
            TotalPrice = Booking.TotalPrice,
            PropertyName = Booking.Property.Name,

        };

    }






    public IEnumerable<GuestBookingsHistory>? GetGuestBookings(string UserTD)
    {
        IEnumerable<Booking>? Bookings = _IGuestSectionRepo.GetGuestBookings(UserTD);
        if (Bookings is null)
        {
            return null;
        }

        List<GuestBookingsHistory>? ConvertBookingToDto =
            Bookings.Select(p => new GuestBookingsHistory
            {
                HostName = p.User?.FirstName,
                BookId = p.Id,
                CheckInDate = p.CheckInDate,
                CheckOutDate = p.CheckOutDate,
                TotalPrice = p.TotalPrice,
                PropertyName = p.Property?.Name


            }).ToList();

        return ConvertBookingToDto;
    }

    //public GuestProfileReedDTO GuestProfileRead(string UserId)
    //{
    //    User UserData = _IGuestSectionRepo.GuestProfileRead(UserId);

    //    return new GuestProfileReedDTO
    //    {
    //        UserId = UserData.Id,
    //        Email = UserData.Email,
    //        PhoneNumber = UserData.PhoneNumber,
    //        FirstName = UserData.FirstName,
    //        LastName = UserData.LasttName,
    //        About =UserData.About

    //    };
    //}

    public bool Remove(Guid BookingiD)
    {

        _IGuestSectionRepo.RemoveFromDB(BookingiD);
        int numberOfAffectedRows = _IGuestSectionRepo.SaveChanges();
        return numberOfAffectedRows > 0;

    }

   
}
