using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Airbnb.BL
{
    public class HomePageProperty
    {

        public Guid Id { get; set; }
        public string Name { get; set; } = string.Empty;
        List<string> imgUrl { get; set; }
        public double PricePerNight { get; set; }
        public String CityName { get; set; } = string.Empty;
        public String CountryName { get; set; } = string.Empty;
        public double propertyAllRating { get; set; }



    }
}
