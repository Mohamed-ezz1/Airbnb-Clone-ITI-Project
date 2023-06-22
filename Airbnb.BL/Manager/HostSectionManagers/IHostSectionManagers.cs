using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;

namespace Airbnb.BL
{
    public interface  IHostSectionManagers
    {
        IEnumerable<HostBookingsDto> GetHostBooking(string id);

        IEnumerable<HostPropertiesDto>  GetHostProperties(string id);
    }
}
