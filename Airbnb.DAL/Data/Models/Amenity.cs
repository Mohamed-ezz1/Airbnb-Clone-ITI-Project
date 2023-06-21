using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Airbnb.DAl;
public class Amenity
{
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public string Icon { get; set; } = string.Empty;    //Url
    public IEnumerable<PropertyAmenity> AmenitiesProperty { get; set; } = new List<PropertyAmenity>();
}
