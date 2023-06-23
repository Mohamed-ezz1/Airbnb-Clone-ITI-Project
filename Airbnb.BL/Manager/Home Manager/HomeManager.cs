using Airbnb.DAl;
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
    private readonly IPropertyRepo _propertyRepo;
    public HomeManager(IPropertyRepo propertyRepo)
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
                PropertyAllRating = p.OverALLReview

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
                //CategoryIcon = c.Icon
            });
        return catsDto;
    }
}
