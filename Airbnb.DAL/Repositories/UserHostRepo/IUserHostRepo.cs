using Airbnb.DAl;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Airbnb.DAL
{
    public interface IUserHostRepo
    {
        IEnumerable<Booking>  GetHostBookingBD(string id);

    }
}
