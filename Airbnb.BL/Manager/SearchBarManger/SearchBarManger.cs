using Airbnb.DAL;
using Airbnb.DAL.Data;
using Microsoft.AspNetCore.Authentication;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Airbnb.BL
{
    public class SearchBarManger : ISearchBarManger

    {
        private readonly ICountriesRepositories CountriesRepositories;
public SearchBarManger(ICountriesRepositories countriesRepositories) {

           CountriesRepositories = countriesRepositories;
        }
        


      

        public List < GetNavbarSearchdto> GetSearchBarData()
        {

            return CountriesRepositories.GetcountrywithCities().Select(p => new GetNavbarSearchdto { CountryId = p.Id, Countryname = p.CountryName, NavbarCities = p.Cities.Select(p => new NavbarCity { CityId = p.Id, Cityname = p.CityName }) }).ToList();
        }
    }




    
}



  

