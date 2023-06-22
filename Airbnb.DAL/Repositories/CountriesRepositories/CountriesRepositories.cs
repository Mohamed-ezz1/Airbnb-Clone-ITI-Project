using Airbnb.DAl;
using Airbnb.DAL.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Airbnb.DAL;
    public  class CountriesRepositories : ICountriesRepositories
    {
    private readonly AircbnbContext aircbnbContext;
    public CountriesRepositories(AircbnbContext _aircbnbContext) {

        aircbnbContext= _aircbnbContext;


    }
        public IEnumerable<Country> GetcountrywithCities()
        {
        return aircbnbContext.Countries.Include(P => P.Cities).ToList(); 
    }
    }

