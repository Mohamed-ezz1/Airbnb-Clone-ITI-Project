using System.Reflection;
using System.Security.Claims;
using Airbnb.BL;
using Airbnb.DAL;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Airbnb.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PropertyController : ControllerBase
    {
        private readonly IPropertyManager _propertyManager;
        private readonly IUserMangers _userMangers;

        public PropertyController(IPropertyManager propertyManager, IUserMangers userMangers)
        {
            _propertyManager = propertyManager;
            _userMangers = userMangers;
        }

        [HttpGet]
        [Route("{PropertyId}")]
        public ActionResult<GetPropertyDetailsDto> GetPropertyById(Guid PropertyId)
        {
            GetPropertyDetailsDto? Property = _propertyManager.FindPropertyById(PropertyId);
            if (Property == null)
            {
                return NotFound();
            }
            return Property;
        }

        [HttpPost]
        [Route("Booking")]
        public IActionResult Add(AddBookingDto booking)
        {
            if (User?.Identity?.IsAuthenticated != true)
            {
                return BadRequest("No users login");
            }
            var userId = User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.NameIdentifier)?.Value;
            bool isBookingAdded = _propertyManager.AddBooking(booking, userId!);
            if (isBookingAdded)
            {
                return StatusCode(StatusCodes.Status201Created);
            }
            else
            {
                return BadRequest("Booking cant be added");
            }
        }

    }
}
