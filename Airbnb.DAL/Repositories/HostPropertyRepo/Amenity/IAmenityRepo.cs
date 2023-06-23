using Airbnb.DAl;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Airbnb.DAL;

public interface IAmenityRepo
{
    IEnumerable<Amenity> GetAmenities();
    int SaveChanges();
}
