using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Airbnb.DAL;

public interface IPropertyDetailsRepo
{
    Property? FindPropertyById(Guid id);

    bool Add(Booking booking);
    bool IsBookingDateRangeOverlap(Booking newBooking);
    IEnumerable<Booking> GetBookingsByPropertyId(Guid propertyId);
    int SaveChanges();
}
