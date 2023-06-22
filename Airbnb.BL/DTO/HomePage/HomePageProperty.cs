using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Airbnb.BL
{
    public class HomePageProperty
    {

        public Guid PropertyId { get; set; }
        public string PropertyName { get; set; } = string.Empty;
        public ICollection<string> ImgUrl { get; set; } = new List<string>();   
        public double PricePerNight { get; set; }
        public string CityName { get; set; } = string.Empty;
        public string CountryName { get; set; } = string.Empty;
        public double propertyAllRating { get; set; }



    }
}
