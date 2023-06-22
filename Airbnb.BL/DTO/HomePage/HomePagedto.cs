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

        public List<HomePageCategoryDto> GetCategoryDtos { get; set; }
        public List<HomePageProperty> homePageProperties { get; set; }



    }
}
