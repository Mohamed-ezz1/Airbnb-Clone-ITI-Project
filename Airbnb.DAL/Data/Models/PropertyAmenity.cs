using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Airbnb.DAl;

public class PropertyAmenity
{
    public Guid propertyId { get; set; }

    public Property? Property { get; set; } 

    public int AminityId { get; set; }
    public Amenity? Amenity { get; set; } 

}
