using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Airbnb.DAl;

public class Booking
{
    [Key]
    public Guid Id { get; set; }
    
    public int UserId { get; set; }
    public User? User { get; set; } 
    public Guid PropertyId { get; set; }
    public Property? Property { get; set; }
    public DateTime CheckInDate { get; set; }
    public DateTime CheckOutDate { get; set; }
    public double TotalPrice { get; set; }
    public DateTime BookingDate { get; set; }
    public int NumberOfGuests { get; set; }
}
