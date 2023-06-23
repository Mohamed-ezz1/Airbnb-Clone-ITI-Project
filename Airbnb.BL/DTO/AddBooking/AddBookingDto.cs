using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Airbnb.BL;

public class AddBookingDto
{
    //Post dto
    public Guid PropertyId { get; set; }
    public DateTime StartDate { get; set; } = DateTime.Now;
    public DateTime EndDate { get; set; } = DateTime.Now;
    public int NumOfGuest { get; set; }
    public int NumOfNight { get; set; }
}

public class BookingDto
{
    public DateTime CheckInDate { get; set; }
    public DateTime CheckOutDate { get; set; }
}