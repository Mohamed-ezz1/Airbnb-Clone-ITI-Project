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
        public string PropertyName { get; set; } = string.Empty;
        public double price { get; set; }
        public string Street { get; set; } = string.Empty;
        public string CountryName { get; set; } = string.Empty;
        public string CityName { get; set; } = string.Empty;


    }
}
