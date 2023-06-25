using System.Security.Claims;
using Airbnb.BL;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Airbnb.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GuestsSectionController : ControllerBase
    {
    
        private readonly IGuestSectionManager _GuestSectionManager;

        public GuestsSectionController(IGuestSectionManager patientsManager)
        {
            _GuestSectionManager = patientsManager;
        }


        [HttpGet]
        [Route("GuestBooking")]
        [Authorize]
        public ActionResult<IEnumerable<GuestBookingsHistory>> GetGuestBookings()
        {
            var userId = User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.NameIdentifier)?.Value;

            List<GuestBookingsHistory> Bookings = _GuestSectionManager.GetGuestBookings(userId!)!.ToList();
            if (Bookings is null)
            {
                return NotFound();
            }
            return Bookings;
        }




        [HttpDelete]
        [Route("{BookId}")]
        [Authorize]
        public ActionResult<GuestBookingsHistory> DeleteGuestBooking(Guid BookId)
        {

            _GuestSectionManager.Remove(BookId);
            return NoContent();
        }

    
    }
}
