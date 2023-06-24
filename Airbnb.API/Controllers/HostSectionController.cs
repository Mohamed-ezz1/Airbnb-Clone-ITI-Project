using Airbnb.BL;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Airbnb.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HostSectionController : ControllerBase
    {
        private readonly IHostSectionManagers _hostSectionManagers;

        public HostSectionController(IHostSectionManagers  hostSectionManagers )
        {
            _hostSectionManagers = hostSectionManagers;
        }

        // get host

        [HttpGet]
        [Route("/HostBooking/{UserId}")]
        public ActionResult<IEnumerable<HostBookingsDto>> GetHostBooking( string UserId )
        {

            IEnumerable<HostBookingsDto> HostBookings = _hostSectionManagers.GetHostBooking(UserId);

            if (HostBookings == null )
            {
                return NotFound();

            }
            return Ok(HostBookings);
        }



        [HttpGet]
        [Route("/HostProperty/{UserId}")]
        public ActionResult<List<HostPropertiesDto>> GetHostProperties(string UserId)
        {
            if (User?.Identity?.IsAuthenticated != true)
            {
                return BadRequest("No users login");
            }

            IEnumerable<HostPropertiesDto>  hostProperties = _hostSectionManagers.GetHostProperties(UserId);

            if (hostProperties == null)
            {
                return BadRequest("there is no property added");

            }
            return Ok(hostProperties);
        }


    }
}
