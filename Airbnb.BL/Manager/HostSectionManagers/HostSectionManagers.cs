using Airbnb.DAl;
using Airbnb.DAL;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Airbnb.BL
{
    public class HostSectionManagers : IHostSectionManagers
    {
        private readonly IUserHostRepo _userHostRepo;
        private readonly IPropertyHost _propertyHost;

        public HostSectionManagers(IUserHostRepo userHostRepo , IPropertyHost propertyHost )
        {
            _userHostRepo = userHostRepo;
           _propertyHost = propertyHost;
        }
        public IEnumerable<HostBookingsDto> GetHostBooking(string id)
        {
            IEnumerable<Booking> host = _userHostRepo.GetHostBookingBD(id);
            IEnumerable<HostBookingsDto> hostBookingsDtos = host.Select(x => new HostBookingsDto
            {
                 GuestName = x.User.FirstName +""+x.User.LasttName,
                 PropertyName = x.Property.Name,
                 CheckInDate = x.CheckInDate,
                 CheckOutDate = x.CheckOutDate,
                 TotalPrice = x.TotalPrice,

            });

            return hostBookingsDtos;
        }

        public IEnumerable<HostPropertiesDto> GetHostProperties(string id)
        {
            IEnumerable<Property> hostPropery = _propertyHost.GetHostPropertiesDB(id);
            
            IEnumerable<HostPropertiesDto> hostBookingsDtos = hostPropery.Select(p => new HostPropertiesDto
            {
              PropertyName = p.Name,
              MaxGuests = p.MaximumNumberOfGuests,
              Price = p.PricePerNight,
              CityName = p.City.CityName,
              CountryName = p.City.Country.CountryName,
                Street = p.Address 

            });


            return hostBookingsDtos;
        }
    }
}
