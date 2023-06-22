using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Airbnb.BL;


public class NavbarSearchdto
{
    public int Country_Id { get; set; }
    public String Country_name { get; set; }
    public List<Navbar_City> navbar_Cities { get; set; }

}



public class Navbar_City
{

    public int CityId { get; set; }
    public String Cityname { get; set; } = string.Empty;
}
