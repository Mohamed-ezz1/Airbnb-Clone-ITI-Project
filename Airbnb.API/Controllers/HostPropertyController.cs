using Airbnb.BL;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Reflection;

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
            var lists= _hostPropertyManager.GetAddPropertyLists();

            return Ok(lists);
             
        }

        [HttpPost]
        public ActionResult PostAddProperty(PropertyPostAddDto propertyPostAddDto)
        {
            _hostPropertyManager.postAddPropertyHost(propertyPostAddDto);

            return NoContent();
        }

        [HttpGet]
        [Route("GetUpdate")]
        public ActionResult GetUpdateProperty(Guid id)
        {
            var PropertyGetUpdate = _hostPropertyManager.GetUpdatePropertyContent(id);
            return Ok(PropertyGetUpdate);
        }

        [HttpPut]
        public ActionResult UpdateProperty(PropertyPostUpdateDto propertyPostUpdateDto )
        {
            var IsFound = _hostPropertyManager.UpdateHostProperty(propertyPostUpdateDto);
            if (!IsFound)
            {
                NotFound();
            }
            return NoContent();


        }


       
    }
}
