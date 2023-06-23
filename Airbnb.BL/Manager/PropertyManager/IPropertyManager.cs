using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Airbnb.BL;

public interface IPropertyManager
{
    GetPropertyDetailsDto? FindPropertyById(Guid propertyId);
    public bool AddBooking(AddBookingDto bookingDto);
    //public IEnumerable<BookingDto> GetBookingsByPropertyId(Guid propertyId);
}
