using Airbnb.DAL.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace Airbnb.DAL;

public class PropertyRepo : IPropertyRepo
{
    private readonly AircbnbContext _context;
    public PropertyRepo(AircbnbContext context)
    {
        _context = context;
    }

    public IEnumerable<Property> GetAllProps()
    {
        return _context.Set<Property>()
            .Include(p => p.City).ThenInclude(p => p.Country)
            .Include(p => p.PropertyImages)
            .AsNoTracking();
            
    }

    public IEnumerable<Category> GetAllCategs()
    {
        return _context.Set<Category>().AsNoTracking();
    }

    public IEnumerable<UserType> GetUser()
    {
        return _context.Users.Select(u => u.UserType).ToList();
    }

    public Category GetCategoryById(int id)
    {
        return _context.Categories.Where(cat => cat.Id == id).FirstOrDefault();
    }
}
