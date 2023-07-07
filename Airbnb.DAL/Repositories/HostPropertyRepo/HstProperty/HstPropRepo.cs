
using Airbnb.DAL.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace Airbnb.DAL;

public class HstPropRepo : IHstPropRepo
{
    private readonly AircbnbContext _aircbnbContext;

    public HstPropRepo(AircbnbContext aircbnbContext)
    {
        _aircbnbContext = aircbnbContext;
    }
    //comment
    public User? GetUserById(string id)
    {
        return _aircbnbContext.Set<User>().FirstOrDefault(u => u.Id == id);
    }
    public bool Add(Property property)
    {
        _aircbnbContext.Set<Property>()
            .Add(property);
        return true;
    }

    public bool Update(Property property)
    {
        return true;
    }

    public int SaveChanges()
    {
        return _aircbnbContext.SaveChanges();
    }

    public Property? GetPropertyById(Guid id)
    {
        //return _aircbnbContext.Set<Property>()
        //    .Include(x=>x.PropertyImages)
        //    .Include(x=>x.PropertyAmenities)
        //         .ThenInclude(x=>x.Amenity)
        //    .FirstOrDefault(x=>x.Id == id);

        return _aircbnbContext.Set<Property>()
            .Include(x => x.PropertyImages)
            .Include(x => x.PropertyAmenities)
                 .ThenInclude(x => x.Amenity)
            .Include(x => x.City)
                .ThenInclude(x => x!.Country)
            .FirstOrDefault(x => x.Id == id);
    }

    public Property? GetPropertyToDeleteById(Guid id)
    {
        return _aircbnbContext.Set<Property>()
            .Include(x => x.PropertyBookings)
            .FirstOrDefault(x => x.Id == id);
    }
}
