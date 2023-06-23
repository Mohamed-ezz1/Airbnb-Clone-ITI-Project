using Airbnb.DAL.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Airbnb.DAL
{
    public class UserDetailsRepositories : IUserDetailsRepositories
    {

        private readonly AircbnbContext aircbnbContext;
        public UserDetailsRepositories(AircbnbContext _aircbnbContext)
        {

            aircbnbContext = _aircbnbContext;


        }
        public UserType GetUserType(string Id)
        {
            return aircbnbContext.Users.First(p => p.Id == Id).UserType;
        }
    }
}
