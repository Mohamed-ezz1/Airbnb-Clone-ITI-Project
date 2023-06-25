using Airbnb.BL;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Airbnb.API.Controllers
{
     
[Route("api/[controller]")]
    [ApiController]
    public class UserDetailsController : ControllerBase
    {
      
        private readonly IUserMangers userMangers;
            public UserDetailsController(IUserMangers _userMangers ) {


            userMangers = _userMangers;    


        }


        [HttpGet]
        [Route("UserType/{id}")]

        public ActionResult<string> GetUserType(string id) {
            if (id == null ) {

                return NotFound();
            }
        
       return  userMangers.GetUserType(id);
        
        
        }

        [HttpGet]
        [Authorize]
        public ActionResult<GuestProfileReedDTO> GuestProfileRead(string UserId)
        {
            GuestProfileReedDTO GuestProfile = userMangers.GuestProfileRead(UserId);

            return GuestProfile;


        }


        [HttpPut]
        [Authorize]
        public ActionResult<GuestProfileUpdateDto> GuestProfileUpdate(GuestProfileUpdateDto GuestInfo)
        {
            bool isSuccessful = userMangers.UpdateGuestInfo(GuestInfo);
            if (!isSuccessful)
            {
                return BadRequest();
            }

            return NoContent();

        }

    }
}
