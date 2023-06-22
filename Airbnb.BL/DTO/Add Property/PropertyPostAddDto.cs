using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Airbnb.BL;

public class PropertyPostAddDto
{
    public string PropertyName { get; set; } =string.Empty;
    public ICollection<string> ImagesURLs { get; set; } = new List<string>();
    public int MaxNumberOfGuests { get; set; }
    public int BedroomsCount { get; set; }
    public int BathroomsCount { get; set; }
    public int PricePerNight { get;set; }
    public int CategoryId { get; set; }
 //   public int CountryId { get; set; }
    public int cityId { get; set; }
    public string Address { get; set; } = string.Empty;
    public string  Description { get; set; } = string.Empty;
    public ICollection<int> AmenitiesId { get; set; } = new List<int>();

}
