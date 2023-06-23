using System.Reflection;
using Airbnb.BL;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Airbnb.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PropertyController : ControllerBase
    {
        private readonly IPropertyManager _propertyManager;
        public PropertyController(IPropertyManager propertyManager)
        {
            _propertyManager = propertyManager;
        }
        
        [HttpGet]
        [Route("{id}")]
        public ActionResult<GetPropertyDetailsDto> GetPropertyById(Guid id) 
        {
            GetPropertyDetailsDto? Property = _propertyManager.FindPropertyById(id);
            if (Property == null)
            {
                return NotFound();
            }
            return Property;
        }

        [HttpPost]
        [NoCollidingDateRange]
        public ActionResult Add(AddBookingDto booking)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }
            _propertyManager.AddBooking(booking);
            return StatusCode(StatusCodes.Status201Created);
        }
    }
}
