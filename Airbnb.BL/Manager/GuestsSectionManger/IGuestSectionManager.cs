using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Airbnb.BL;

public interface IGuestSectionManager
{
    public GuestBookingsHistory? GetGuestBooking(Guid bookTd);



    public IEnumerable<GuestBookingsHistory>? GetGuestBookings(string userTD);
    GuestProfileReedDTO GuestProfileRead(string userId);

    public bool Remove(Guid booking);
   
}
