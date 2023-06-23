using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Airbnb.BL;

public interface IHomeManager
{
    IEnumerable<HomePagePropertyDto> GetAllPropsAsDtos();
    IEnumerable<HomePageCategoryDto> GetAllCatsAsDtos();
    IEnumerable<HomePagePropertyDto> FilteredProperties(Query Search );
}
