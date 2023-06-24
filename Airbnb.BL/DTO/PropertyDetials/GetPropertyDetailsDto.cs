using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Airbnb.BL;

public class GetPropertyDetailsDto
{
    public string NameOfProperty { get; set; } = string.Empty;
    public double RatingOverroll { get; set; }
    public int MaxNumOfGuest { get; set; }
    public int NumOfReview { get; set; }
    public string CityNmae { get; set; } = string.Empty;
    public string CountryNmae { get; set; } = string.Empty;
    public IEnumerable<string> Imgs { get; set; } = new List<string>();    
    public string UserName { get; set; } = string.Empty;
    public string UserImage { get; set; } = string.Empty;
    public int BedRoomCount { get; set; }
    public double PricePerNight { get; set; }
    public string PropertyDescription { get; set; } = string.Empty;
    public IEnumerable<AmintsDTO> Aminties { get; set; } =new HashSet<AmintsDTO>();
    public IEnumerable<PropertyBookingDates> BookingDates { get; set; } = new HashSet<PropertyBookingDates>();
};

public class PropertyBookingDates
{
    public DateTime CheckInDate { get; set; } = DateTime.Now;
    public DateTime CheckOutDate { get; set; } = DateTime.Now;

}



public class AmintsDTO
{
    public string AmintiesName { get; set; } = string.Empty;
    public string Icon { get; set; } = string.Empty;

}
