using Airbnb.DAl;
using Airbnb.DAL.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;

namespace Airbnb.DAL;

public class CountryRepo: ICounrtyRepo
{
    private readonly AircbnbContext _aircbnbContext;

    public CountryRepo(AircbnbContext aircbnbContext)
    {
        _aircbnbContext = aircbnbContext;
    }

    public IEnumerable<Country> GetCountries()
    {
        return _aircbnbContext.Countries.Include(x => x.Cities);
    }

    public int SaveChanges()
    {
        return _aircbnbContext.SaveChanges();
    }
}
