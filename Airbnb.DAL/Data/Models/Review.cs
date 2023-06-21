using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Airbnb.DAl;

public class Review
{
    public int Id { get; set; }
    public int PropertyId { get; set; }
    public Property Property { get; set; } = new();
    public int UserId { get; set; }
    public User User { get; set; } = new();
    public int BookingId { get; set; }
    public Booking Booking { get; set; } = new();
}
