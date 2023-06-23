using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Airbnb.DAl;

namespace Airbnb.DAL;

public interface IPropertyDetailsRepo
{
    Property? FindPropertyById(Guid id);

     void Add(Booking booking);
    IEnumerable<Booking> GetBookingsByPropertyId(Guid propertyId);
    int SaveChanges();
}
