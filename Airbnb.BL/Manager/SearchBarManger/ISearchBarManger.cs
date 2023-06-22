using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Airbnb.BL
{
    public interface ISearchBarManger
    {
        List<GetNavbarSearchdto> GetSearchBarData();
    }
}
