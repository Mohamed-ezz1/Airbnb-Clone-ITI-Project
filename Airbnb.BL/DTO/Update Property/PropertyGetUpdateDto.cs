using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Airbnb.BL;

public class PropertyGetUpdateDto
{
    public string? PropertyName { get; set; }
    public  Guid PropertyId { get; set; }
    public ICollection<ImageOfUpdatePropertyDto> Images { get; set; } = new List<ImageOfUpdatePropertyDto>();
    public int MaxNumberOfGuests { get; set; }
    public int BedroomsCount { get; set; }
    public int BathroomsCount { get; set; }
    public int PricePerNight { get; set; }
    public ICollection<CategoryOfUpdateDto> Categories { get; set; } = new List<CategoryOfUpdateDto>();
    public ICollection<CountryOfUpdateDto> Countries { get; set; } = new List<CountryOfUpdateDto>();
    public ICollection<CityofUpdateDto> Cities { get; set; } = new List<CityofUpdateDto>();
    public string? Address { get; set; }
    public string? Description { get; set; }
    public ICollection<AmenitiesOfUpdatePropertyDto> Amenities { get; set; } = new List<AmenitiesOfUpdatePropertyDto>();
}
