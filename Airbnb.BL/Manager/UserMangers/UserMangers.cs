using Airbnb.DAl;
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




        public GuestProfileReedDTO GuestProfileRead(string UserId)
        {
            User UserData = userDetails.GuestProfileRead(UserId);

            return new GuestProfileReedDTO
            {
                Email = UserData.Email,
                PhoneNumber = UserData.PhoneNumber,
                FirstName = UserData.FirstName,
                LastName = UserData.LasttName,
                About = UserData.About

            };
        }

        public bool UpdateGuestInfo(GuestProfileUpdateDto guestInfoUodate)
        {
            User User = userDetails.GetUesrInfo(guestInfoUodate.UserId);


            User.Id = guestInfoUodate.UserId;
                User.FirstName = guestInfoUodate.FirstName;
            User.LasttName = guestInfoUodate.LastName;
            User.Email = guestInfoUodate.Email;
            User.About = guestInfoUodate.About;

            return userDetails.SaveChanges() > 0;

        }
    }
}
