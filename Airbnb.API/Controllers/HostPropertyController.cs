using Airbnb.BL;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Reflection;
using System.Security.Claims;

namespace Airbnb.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HostPropertyController : ControllerBase
    {
        private readonly IHostPropertyManager _hostPropertyManager;

        public HostPropertyController(IHostPropertyManager hostPropertyManager)
        {
            _hostPropertyManager = hostPropertyManager;
        }

        [HttpGet]
        public ActionResult GetAddProperty()
        {
            var lists = _hostPropertyManager.GetAddPropertyLists();

            return Ok(lists);

        }

        [HttpPost]
        public ActionResult PostAddProperty(PropertyPostAddDto propertyPostAddDto)
        {
            if (User?.Identity?.IsAuthenticated != true)
            {
                return BadRequest("No users login");
            }
            var userId = User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.NameIdentifier)?.Value;

            bool isAdded = _hostPropertyManager.AddProperty(propertyPostAddDto, userId!);
            if (isAdded)
            {
                return StatusCode(StatusCodes.Status201Created);
            }
            else
            {
                return BadRequest("Property is not added");
            }

        }

        [HttpGet]
        [Route("{id}")]
        public ActionResult GetUpdateProperty(Guid id)
        {
            var PropertyGetUpdate = _hostPropertyManager.GetUpdatePropertyContent(id);
            return Ok(PropertyGetUpdate);
        }

        [HttpPut]
        public ActionResult UpdateProperty(PropertyPostUpdateDto propertyPostUpdateDto)
        {
            var IsFound = _hostPropertyManager.UpdateHostProperty(propertyPostUpdateDto);
            if (!IsFound)
            {
                NotFound();
            }
            return NoContent();


        }

        [HttpPut]
        [Route("{id}")]
        public ActionResult DeleteProperty(Guid id)
        {
            var isNotDeleted = _hostPropertyManager.DeleteProperty(id);
            if (isNotDeleted)
            {
                return BadRequest("Cant delete a property that have booking in 7 days");
            }
            return Ok("Deleted");
        }



    }
}
