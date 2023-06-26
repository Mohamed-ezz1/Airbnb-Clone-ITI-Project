using Airbnb.DAL.Data;
using Microsoft.EntityFrameworkCore;

namespace Airbnb.DAL
{
    public class UserHostRepo : IUserHostRepo
    {
        private readonly AircbnbContext _aircbnbContext;

        public UserHostRepo(AircbnbContext aircbnbContext)
        {
            _aircbnbContext = aircbnbContext;
        }
        public IEnumerable<Booking> GetHostBookingBD(string id)
        {
            return _aircbnbContext.Bookings
                .Include(p => p.Property)
                .Include(p => p.User)
                .Where(p => p.Property!.UserId == id);

        }

        public IEnumerable<Property> GetHostPropertiesDB(string id)
        {

            return _aircbnbContext.Properties
                .Include(p => p.User)
                .Include(p => p.City)
                    .ThenInclude(p => p.Country)
                .Where(p => p.UserId == id);


        }



    }
}
