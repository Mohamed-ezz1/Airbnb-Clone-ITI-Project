using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Airbnb.BL;


public class GetNavbarSearchdto
{
    public int CountryId { get; set; }
    public string Countryname { get; set; }
    public ICollection<NavbarCity> NavbarCities { get; set; }= new List<NavbarCity>();

}



public class NavbarCity
{

    public int CityId { get; set; }
    public string Cityname { get; set; } = string.Empty;
}
