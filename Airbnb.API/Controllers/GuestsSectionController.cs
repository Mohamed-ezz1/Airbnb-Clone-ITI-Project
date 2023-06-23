using Airbnb.BL;
using Airbnb.DAl;
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
        [Route("{UserTD}")]
        public ActionResult<IEnumerable<GuestBookingsHistory>> GetGuestBookings(string UserTD)
        {

            List<GuestBookingsHistory>? Bookings = _GuestSectionManager.GetGuestBookings(UserTD).ToList();
            if (Bookings is null)
            {
                return NotFound();
            }
            return Bookings;
        }




        [HttpDelete]
        [Route("{BookId}")]
        public ActionResult<GuestBookingsHistory> DeleteGuestBooking(Guid BookId)
        {

            _GuestSectionManager.Remove(BookId);
            return NoContent();
        }

    
    }
}
