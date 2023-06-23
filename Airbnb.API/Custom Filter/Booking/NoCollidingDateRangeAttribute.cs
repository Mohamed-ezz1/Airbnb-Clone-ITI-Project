using Airbnb.BL;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Mvc;
using Airbnb.DAl;

namespace Airbnb.API;

public class NoCollidingDateRangeAttribute : ActionFilterAttribute
{
    public override void OnActionExecuting(ActionExecutingContext context)
    {
        var bookingDto = context.ActionArguments["booking"] as AddBookingDto;

        if (bookingDto != null)
        {
            IEnumerable<Booking>? propertyBookings = context.HttpContext.Items["PropertyBookings"] as IEnumerable<Booking>;

            if (propertyBookings != null && propertyBookings.Any(range =>
                bookingDto.StartDate < range.CheckOutDate && bookingDto.EndDate > range.CheckInDate))
            {
                context.ModelState.AddModelError("Booking", "The booking date range is colliding with existing bookings.");
            }
        }

        base.OnActionExecuting(context);
    }
}

