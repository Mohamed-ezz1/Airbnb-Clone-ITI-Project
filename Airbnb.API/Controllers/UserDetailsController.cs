using System.Security.Claims;
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
        public UserDetailsController(IUserMangers _userMangers)
        {


            userMangers = _userMangers;


        }


        [HttpGet]
        [Route("UserType")]

        public ActionResult<Usertypedto> GetUserType()
        {
            if (User?.Identity?.IsAuthenticated != true)
            {
                return BadRequest("No users login");
            }
            var userId = User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.NameIdentifier)?.Value;
            if (userId == null)
            {

                return NotFound();
            }

            return userMangers.GetUserType(userId);


        }

        [HttpGet]
        [Authorize]
        public ActionResult<GuestProfileReedDTO> GuestProfileRead()
        {
            if (User?.Identity?.IsAuthenticated != true)
            {
                return BadRequest("No users login");
            }
            var userId = User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.NameIdentifier)?.Value;
            GuestProfileReedDTO GuestProfile = userMangers.GuestProfileRead(userId!);

            return GuestProfile;


        }


        [HttpPut]
        [Authorize]
        public ActionResult<GuestProfileUpdateDto> GuestProfileUpdate(GuestProfileUpdateDto GuestInfo)
        {
            var userId = User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.NameIdentifier)?.Value;

            bool isSuccessful = userMangers.UpdateGuestInfo(GuestInfo, userId);
            if (!isSuccessful)
            {
                return BadRequest();
            }

            return NoContent();

        }

    }
}
