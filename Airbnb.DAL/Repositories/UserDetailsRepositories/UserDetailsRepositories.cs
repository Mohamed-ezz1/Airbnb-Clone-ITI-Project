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
    public class UserDetailsRepositories : IUserDetailsRepositories
    {

        private readonly AircbnbContext aircbnbContext;
        public UserDetailsRepositories(AircbnbContext _aircbnbContext)
        {

            aircbnbContext = _aircbnbContext;


        }

        public User? GetUesrInfo(string userId)
        {
         return   aircbnbContext.Users.Where(p => p.Id == userId).FirstOrDefault();

        }

        public UserType GetUserType(string Id)
        {
            return aircbnbContext.Users.First(p => p.Id == Id).UserType;
        }
        public User GuestProfileRead(string UserId)
        {
            return aircbnbContext.Users.Where(p => p.Id == UserId).FirstOrDefault();
        }
        public int SaveChanges()
        {
            return aircbnbContext.SaveChanges();
        }
    }
}
