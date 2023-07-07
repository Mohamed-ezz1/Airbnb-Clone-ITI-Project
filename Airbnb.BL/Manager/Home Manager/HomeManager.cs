using Airbnb.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace Airbnb.BL;

public class HomeManager : IHomeManager
{
    private readonly IPropertiesRepo _propertyRepo;
    public HomeManager(IPropertiesRepo propertyRepo  )
    {
        _propertyRepo = propertyRepo;
    }

    
    public IEnumerable<HomePagePropertyDto> GetAllPropsAsDtos()
    {
        IEnumerable<Property> propsFromDb = _propertyRepo.GetAllProps();
        IEnumerable<HomePagePropertyDto> propsDto = propsFromDb
            .Select(p => new HomePagePropertyDto
            {
                PropertyId = p.Id,
                PropertyName = p.Name,
                ImgUrl = p.PropertyImages.Select(im => im.Image).ToList(),
                PricePerNight = p.PricePerNight,
                CityName = p.City.CityName,
                CountryName = p.City.Country.CountryName,
                //PropertyAllRating = p.OverALLReview

            }); ;
        return propsDto;
    }

    public IEnumerable<HomePageCategoryDto> GetAllCatsAsDtos()
    {
        IEnumerable<Category> categsFromDb = _propertyRepo.GetAllCategs();
        IEnumerable<HomePageCategoryDto> catsDto = categsFromDb
            .Select(c => new HomePageCategoryDto
            {
                CategoryId = c.Id,
                CategoryName = c.Name,
                CategoryIcon = c.Icon
            });
        return catsDto;
    }

    public IEnumerable<HomePagePropertyDto> FilteredProperties(Query Search)
    {

        var PropertiesBeforeFilter=  _propertyRepo.GetAllProps() ;


        if (Search.NumberOfGuests == null)
        {
            Search.NumberOfGuests =0;
        }
        if (Search.CatogreyId != null)
        {

            PropertiesBeforeFilter = PropertiesBeforeFilter.Where(p => p.CategoryId == Search.CatogreyId);
        }
        if(Search.CityId != null)
        {

            PropertiesBeforeFilter = PropertiesBeforeFilter.Where(p => p.CityId == Search.CityId);

        }else if(Search.CountryId != null)
        {
           
            PropertiesBeforeFilter = PropertiesBeforeFilter.Where(p => p.City.CounrtyId==Search.CountryId);
        }
        if(Search.NumberOfGuests != null)
        {
            PropertiesBeforeFilter = PropertiesBeforeFilter.Where(p =>   Search.NumberOfGuests <= p.MaximumNumberOfGuests);
        }

        List<HomePagePropertyDto> newhomePageProperty = PropertiesBeforeFilter.Select(p => new HomePagePropertyDto { CityName = p.City.CityName, CountryName=p.City.Country.CountryName , ImgUrl= p.PropertyImages.Select(P=>P.Image).ToList(), PricePerNight=p.PricePerNight , PropertyId=p.Id, PropertyName=p.Name}).ToList();
        return newhomePageProperty;

    }
   
    }

