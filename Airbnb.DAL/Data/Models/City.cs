using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Airbnb.DAl;

public class City
{
    public int Id { get; set; }
    public string CityName { get; set; } = string.Empty;
    public int CounrtyId { get; set; }
    public Country Country { get; set; } = new();
    public IEnumerable<Property> CityProperties { get; set; } = new List<Property>();

}
