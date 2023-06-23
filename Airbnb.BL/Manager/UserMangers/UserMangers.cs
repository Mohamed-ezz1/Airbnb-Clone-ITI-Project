using Airbnb.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Airbnb.BL
{
    public class UserMangers : IUserMangers
    {
        private readonly IUserDetailsRepositories userDetails;
        public UserMangers(IUserDetailsRepositories _userDetails) {

            userDetails = _userDetails;



        }    
        public string GetUserType(string Id)
        {

             return   userDetails.GetUserType(Id).ToString();
        }
    }
}
