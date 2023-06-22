using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Airbnb.BL;

public class PropertyGetAddDto
{
    public ICollection<CategoryDto> Categories { get; set; } = new List<CategoryDto>();
    public ICollection<CountryDto> Countries { get; set; } = new List<CountryDto>();
    public ICollection<CityDto> Cities { get; set; } = new List<CityDto>();
    public ICollection<AmenitiesPropertyDto> Amenities { get; set; } = new List<AmenitiesPropertyDto>();

}
