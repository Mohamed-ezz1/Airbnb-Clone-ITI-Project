using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Airbnb.BL
{
    public class HomePagedto
    {


        public string UserType { get; set; }=string.Empty;

        public ICollection<HomePageCategoryDto> GetCategoryDtos { get; set; }= new List<HomePageCategoryDto>();
        public ICollection<HomePageProperty> homePageProperties { get; set; } = new List<HomePageProperty>();


    }
}
