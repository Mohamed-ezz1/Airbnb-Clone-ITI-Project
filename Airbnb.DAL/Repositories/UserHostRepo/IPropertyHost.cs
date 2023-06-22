using Airbnb.DAl;
using Airbnb.DAL.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Airbnb.DAL
{
    public interface IPropertyHost
    {
        IEnumerable<Property> GetHostPropertiesDB(string id);

    }
}
