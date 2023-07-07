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
        public Usertypedto GetUserType(string Id)
        {
            var usertypestring = userDetails.GetUserType(Id).ToString();
            var usertype = new Usertypedto { UserType= usertypestring };
             return usertype;
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
                About = UserData.About,
                Url=UserData.UserImage



            };
        }

        public bool UpdateGuestInfo(GuestProfileUpdateDto guestInfoUodate, string userId)
        {
            User User = userDetails.GetUesrInfo( userId);


            //User.Id = guestInfoUodate.UserId;
            User.FirstName = guestInfoUodate.FirstName;
            User.LasttName = guestInfoUodate.LastName;
            User.Email = guestInfoUodate.Email;
            User.About = guestInfoUodate.About;
            User.PhoneNumber = guestInfoUodate.PhoneNumber;
            User.UserImage = guestInfoUodate.Url;

            return userDetails.SaveChanges() > 0;

        }
    }
}
