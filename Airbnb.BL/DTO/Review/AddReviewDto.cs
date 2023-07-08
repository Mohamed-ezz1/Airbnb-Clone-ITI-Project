using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Airbnb.BL
{
    public class AddReviewDto
    {
        public Guid Bookingid { get; set; }
        public Guid Propertyid { get; set; }
        public Guid Userid { get; set; }
        public  string Comment { get; set; }
        public int Rate { get; set; }
    }
}
