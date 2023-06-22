using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Airbnb.DAl;

public class Review
{
    public Guid PropertyId { get; set; }
    public Property? Property { get; set; } 
    public string? UserId { get; set; }
    public User? User { get; set; }
    public Guid BookingId { get; set; }
    public Booking? Booking { get; set; }
    [Range(0,5)]
    public int Rate { get; set; }
    
    public DateTime CreatedDate { get; set; }
    [MaxLength(500)]
    public string Comment { get; set; } = string.Empty;
    
}
