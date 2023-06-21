using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Airbnb.DAl;

public class Country
{
    public int Id { get; set; }
    public string CountryName { get; set; } = string.Empty;
    public IEnumerable<City> Cities { get; set; } = new List<City>();
    public IEnumerable<Property> CountryProperties { get; set; } = new List<Property>();
}
