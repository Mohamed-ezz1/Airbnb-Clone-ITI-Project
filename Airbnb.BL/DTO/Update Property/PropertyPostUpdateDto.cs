using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Airbnb.BL;

public class PropertyPostUpdateDto
{
    public Guid PropertyId { get; set; }
    public string? PropertyName { get; set; }
    public ICollection<int> ImagesURLs { get; set; } = new List<int>();
    public int MaxNumberOfGuests { get; set; }
    public int BedroomsCount { get; set; }
    public int BathroomsCount { get; set; }
    public int PricePerNight { get; set; }
    public int CategoryId { get; set; }
    public int CountryId { get; set; }
    public int cityId { get; set; }
    public string? Address { get; set; }
    public string? Description { get; set; }
    public ICollection<int> AmenitiesId { get; set; } = new List<int>();
}
