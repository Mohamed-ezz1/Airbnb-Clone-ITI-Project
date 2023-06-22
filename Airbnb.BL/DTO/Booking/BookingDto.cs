using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Airbnb.BL;

public class BookingDto
{
    public DateTime StartDate { get; set; } = DateTime.Now;
    public DateTime EndDate { get; set; } = DateTime.Now;
    public int NumOfGuest { get; set; }
    public int PriePerNight { get; set; }
    public int NumOfNight { get; set; }
}
