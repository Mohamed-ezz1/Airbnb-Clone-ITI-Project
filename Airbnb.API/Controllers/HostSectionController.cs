using System.Security.Claims;
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
        [Route("/HostBooking")]
        public ActionResult<IEnumerable<HostBookingsDto>> GetHostBooking()
        {

            if (User?.Identity?.IsAuthenticated != true)
            {
                return BadRequest("No users login");
            }
            var userId = User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.NameIdentifier)?.Value;

            IEnumerable<HostBookingsDto> HostBookings = _hostSectionManagers.GetHostBooking(userId!);

            if (HostBookings == null )
            {
                return NotFound();

            }
            return Ok(HostBookings);
        }



        [HttpGet]
        [Route("/HostProperty")]
        public ActionResult<List<HostPropertiesDto>> GetHostProperties()
        {
            if (User?.Identity?.IsAuthenticated != true)
            {
                return BadRequest("No users login");
            }
            var userId = User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.NameIdentifier)?.Value;


            IEnumerable<HostPropertiesDto>  hostProperties = _hostSectionManagers.GetHostProperties(userId!);

            if (hostProperties == null)
            {
                return BadRequest("there is no property added");

            }
            return Ok(hostProperties);
        }


    }
}
