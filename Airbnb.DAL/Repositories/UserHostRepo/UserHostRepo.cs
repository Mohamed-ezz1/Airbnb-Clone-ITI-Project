using Airbnb.DAl;
using Airbnb.DAL.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
                .Where(p => p.UserId == id);

        }

        
    }
}
