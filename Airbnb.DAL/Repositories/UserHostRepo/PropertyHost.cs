using Airbnb.DAL.Data;
using Airbnb.DAl;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace Airbnb.DAL
{
    public class PropertyHost:IPropertyHost
    {
        private readonly AircbnbContext _aircbnbContext;

        public PropertyHost(AircbnbContext  aircbnbContext )
        {
           _aircbnbContext = aircbnbContext;
        }

        IEnumerable<Property> IPropertyHost.GetHostPropertiesDB(string id)
        {
            return _aircbnbContext.Properties
                .Include(p => p.User)
                .Include(p=>p.City)
                    .ThenInclude(p=>p.Country)
                .Where(p => p.UserId == id);
                            
        }
    }
}
