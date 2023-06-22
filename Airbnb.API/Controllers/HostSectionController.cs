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
        [Route("{id}")]
        public ActionResult<IEnumerable<HostBookingsDto>> GetHostBooking( string id )
        {

            IEnumerable<HostBookingsDto> HostBookings = _hostSectionManagers.GetHostBooking( id );

            if (HostBookings == null )
            {
                return NotFound();

            }
            return Ok(HostBookings);
        }



        [HttpGet]
        public ActionResult<List<HostPropertiesDto>> GetHostProperties(string id)
        {

            IEnumerable<HostPropertiesDto>  hostProperties = _hostSectionManagers.GetHostProperties(id);

            if (hostProperties == null)
            {
                return NotFound();

            }
            return Ok(hostProperties);
        }


    }
}
