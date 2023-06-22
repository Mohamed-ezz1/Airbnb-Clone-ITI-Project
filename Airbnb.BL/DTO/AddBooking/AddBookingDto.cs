using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Airbnb.BL;

public class AddBookingDto
{
    //Post dto
    public string UserId { get; set; } = string.Empty;
    public Guid PropertyId { get; set; }
    public DateTime StartDate { get; set; } = DateTime.Now;
    public DateTime EndDate { get; set; } = DateTime.Now;
    public int NumOfGuest { get; set; }
    public int NumOfNight { get; set; }
}
