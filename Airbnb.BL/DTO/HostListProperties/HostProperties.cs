using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Airbnb.BL.DTO.HostListProperties
{
    public class HostProperties
    {
        public Guid PropertyId { get; set; }
        public int MaxGuests { get; set; }


        public double price { get; set; }
        public string Street { get; set; }
        public string CountryName { get; set; }
        public string CityName { get; set; }


    }
}
