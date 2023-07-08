using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Airbnb.BL;

public class GuestBookingsHistory
{
    //GET
    public Guid BookId { get; set; }
    public string HostName { get; set; } = string.Empty;
    public string PropertyName { get; set; } = string.Empty;
    public double TotalPrice { get; set; }
    public DateTime CheckInDate { get; set; }
    public DateTime CheckOutDate { get; set; }
    public bool Status { get; set; }

}
