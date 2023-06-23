
using Airbnb.DAL.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Airbnb.DAL;

public class CategoryRepo : ICategoryRepo
{
    private readonly AircbnbContext _aircbnbContext;

    public CategoryRepo(AircbnbContext aircbnbContext)
    {
        _aircbnbContext = aircbnbContext;
    }

    public IEnumerable<Category> GetCategory()
    {
        return _aircbnbContext.Categories;
    }

    public int SaveChanges()
    {
        return _aircbnbContext.SaveChanges(); 
    }
}
