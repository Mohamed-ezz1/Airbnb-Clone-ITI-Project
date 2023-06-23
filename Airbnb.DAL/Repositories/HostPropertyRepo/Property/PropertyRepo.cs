
using Airbnb.DAL.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Airbnb.DAL;

public class PropertyRepo: IPropertyRepo
{
    private readonly AircbnbContext _aircbnbContext;

    public PropertyRepo(AircbnbContext aircbnbContext)
    {
        _aircbnbContext = aircbnbContext;
    }

    public void Add(Property property)
    {
        _aircbnbContext.Set<Property>()
            
            .Add(property);
    }

    public void Update(Property property)
    {
        
    }

    public int SaveChanges()
    {
        return _aircbnbContext.SaveChanges();
    }

    public Property? GetPropertyById(Guid id)
    {
        return _aircbnbContext.Set<Property>()
            .Include(x=>x.PropertyImages)
            .Include(x=>x.PropertyAmenities)
                 .ThenInclude(x=>x.Amenity)
            .FirstOrDefault(x=>x.Id == id);
    }
}
