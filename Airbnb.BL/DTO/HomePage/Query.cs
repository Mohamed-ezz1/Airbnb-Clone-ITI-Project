using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Airbnb.BL
{
    public class Query
    {


        public int? CityId { get; set; }
        public int? CountryId { get; set; }
        public int? CatogreyId { get; set; }
        public int? NumberOfGuests { get; set; }

    }
}
