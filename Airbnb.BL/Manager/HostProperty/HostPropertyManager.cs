using Airbnb.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Airbnb.BL;

public class HostPropertyManager : IHostPropertyManager
{
    private readonly ICategoryRepo _categoryRepo;
    private readonly IAmenityRepo _amenityRepo;
    private readonly ICounrtyRepo _counrtyRepo;
    private readonly IHstPropRepo _propertyRepo;

    public HostPropertyManager(ICategoryRepo categoryRepo,
        IAmenityRepo amenityRepo,
        ICounrtyRepo counrtyRepo,
        IHstPropRepo propertyRepo)
    {
        _categoryRepo = categoryRepo;
        _amenityRepo = amenityRepo;
        _counrtyRepo = counrtyRepo;
        _propertyRepo = propertyRepo;
    }
    public PropertyGetAddDto? GetAddPropertyLists()
    {
        var allCategorysFromDb = _categoryRepo.GetCategory();
        var allCategoryDto = allCategorysFromDb.Select(x => new CategoryDto
        {
            Id = x.Id,
            Name = x.Name,
        });

        var allAmentiesFromDb = _amenityRepo.GetAmenities();

        var allAmentiesDto = allAmentiesFromDb.Select(x => new AmenitiesPropertyDto
        {
            Id = x.Id,
            Name = x.Name,
        });

        var allCountriesFromDb = _counrtyRepo.GetCountries();

        var allCountriesDto = allCountriesFromDb.Select(x => new CountryDto
        {
            Id = x.Id,
            Name = x.CountryName,
            Cities = x.Cities.Select(x => new CityDto
            {
                Id = x.Id,
                Name = x.CityName,
            }).ToList(),

        });

        var AddPropertyLists = new PropertyGetAddDto
        {
                 Amenities = allAmentiesDto.ToList(),
                 Countries = allCountriesDto.ToList(),
                 Categories= allCategoryDto.ToList(),
        };

        return AddPropertyLists;
    }

    public void postAddPropertyHost(PropertyPostAddDto propertyPostAddDto)
    {
        Property property = new Property
        {
            Id = Guid.NewGuid(),
           
            Name = propertyPostAddDto.PropertyName,
            MaximumNumberOfGuests = propertyPostAddDto.MaxNumberOfGuests,
            RoomCount = propertyPostAddDto.BedroomsCount,
            BathroomCount = propertyPostAddDto.BathroomsCount,
            BedCount = propertyPostAddDto.BedCount,
            PricePerNight = propertyPostAddDto.PricePerNight,
            CategoryId = propertyPostAddDto.CategoryId,
            CityId = propertyPostAddDto.CityId,
            Address = propertyPostAddDto.Address,
            Description = propertyPostAddDto.Description,
            PropertyImages = propertyPostAddDto.ImagesURLs.Select(x => new PropertyImage
            {
                Image = x,
                CreatedDate = DateTime.Now,
                

            }).ToList(),
            PropertyAmenities = propertyPostAddDto.AmenitiesId.Select(x => new PropertyAmenity
            {
                AmenityId = x
            }).ToList()

        };
        _propertyRepo.Add(property);
        _propertyRepo.SaveChanges();
    }

    public PropertyGetUpdateDto? GetUpdatePropertyContent(Guid id)
    {
        var allUpdatedContentFromDb = _propertyRepo.GetPropertyById(id);
        if (allUpdatedContentFromDb == null)
        {
            return null;
        }
        var propertyGetUpdateDto = new PropertyGetUpdateDto
        {
            PropertyId= id,
             
            PropertyName = allUpdatedContentFromDb.Name,
            PricePerNight = allUpdatedContentFromDb.PricePerNight,
            OldCityId = allUpdatedContentFromDb.CityId,
            OldCategoryId = allUpdatedContentFromDb.CategoryId,
            MaxNumberOfGuests = allUpdatedContentFromDb.MaximumNumberOfGuests,
            Description = allUpdatedContentFromDb.Description,
            BedroomsCount = allUpdatedContentFromDb.RoomCount,
            BathroomsCount = allUpdatedContentFromDb.BathroomCount,
            BedCount = allUpdatedContentFromDb.BedCount,
            Address = allUpdatedContentFromDb.Address,

            OldAmenities = allUpdatedContentFromDb.PropertyAmenities.Select(x => x.AmenityId).ToList(),
            Images = allUpdatedContentFromDb.PropertyImages.Select(x => new ImageOfUpdatePropertyDto
            {
                Id = x.Id,
                URL = x.Image,
            }).ToList()


        };

        var allCategorysFromDb = _categoryRepo.GetCategory();
        
        var allCategoryDto = allCategorysFromDb.Select(x => new CategoryOfUpdateDto
        {
            Id = x.Id,
            Name = x.Name,
        });

        var allAmentiesFromDb = _amenityRepo.GetAmenities();

        var allAmentiesDto = allAmentiesFromDb.Select(x => new AmenitiesOfUpdatePropertyDto
        {
            Id = x.Id,
            Name = x.Name,
        });

        var allCountriesFromDb = _counrtyRepo.GetCountries();

        var allCountriesDto = allCountriesFromDb.Select(x => new CountryOfUpdateDto
        {
            Id = x.Id,
            Name = x.CountryName,
            Cities = x.Cities.Select(x => new CityofUpdateDto
            {
                Id = x.Id,
                Name = x.CityName,
            }).ToList(),

        });


        propertyGetUpdateDto.Amenities = allAmentiesDto.ToList();
        propertyGetUpdateDto.Countries = allCountriesDto.ToList();
        propertyGetUpdateDto.Categories = allCategoryDto.ToList();
            
       

        return propertyGetUpdateDto;
    }

    public bool UpdateHostProperty(PropertyPostUpdateDto propertyPostUpdateDto)
    {
        Property? property = _propertyRepo.GetPropertyById(propertyPostUpdateDto.PropertyId);
        if (property == null) 
        {
            return false;
        }
        property.Name = propertyPostUpdateDto.PropertyName;
        property.Address = propertyPostUpdateDto.Address;
        property.BathroomCount = propertyPostUpdateDto.BathroomsCount;
        property.BedCount = propertyPostUpdateDto.BedCount;
        property.RoomCount = propertyPostUpdateDto.BedroomsCount;
        property.PricePerNight = propertyPostUpdateDto.PricePerNight;
        property.MaximumNumberOfGuests = propertyPostUpdateDto.MaxNumberOfGuests;
        property.Description= propertyPostUpdateDto.Description;
        property.CityId = propertyPostUpdateDto.CityId;
        property.CategoryId = propertyPostUpdateDto.CategoryId;
        property.PropertyImages = propertyPostUpdateDto.ImagesURLs.Select(x => new PropertyImage
        {
            Image = x
        }).ToList();
        property.PropertyAmenities = propertyPostUpdateDto.AmenitiesId.Select(x => new PropertyAmenity
        {
            AmenityId = x
        }).ToList();

        _propertyRepo.Update(property);
        _propertyRepo.SaveChanges();




        return true;
    }
}
