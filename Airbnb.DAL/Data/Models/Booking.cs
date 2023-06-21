using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Airbnb.DAl;

public class Booking
{
    public int Id { get; set; }
    public int UserId { get; set; }
    public User User { get; set; } = new();
    public int PropertyId { get; set; }
    public Property Property { get; set; } = new();
    public DateTime CheckInDate { get; set; }
    public DateTime CheckOutDate { get; set; }
    public double TotalPrice { get; set; }
    public DateTime BookingDate { get; set; }
    public int NumberOfGuests { get; set; }
    public int NumberOfInfants { get; set; }
    public int NumberOfPets { get; set; }
}
