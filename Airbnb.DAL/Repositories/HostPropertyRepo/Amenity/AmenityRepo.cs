using Airbnb.DAL.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;

namespace Airbnb.DAL;

public class AmenitiesRepo: IAmenityRepo
{
    private readonly AircbnbContext _aircbnbContext;

    public AmenitiesRepo(AircbnbContext aircbnbContext)
    {
        _aircbnbContext = aircbnbContext;
    }

    public IEnumerable<Amenity> GetAmenities()
    {
        return _aircbnbContext.Amenities;
    }

    public int SaveChanges()
    {
        return _aircbnbContext.SaveChanges();
    }
}
