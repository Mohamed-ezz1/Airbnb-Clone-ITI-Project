using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Airbnb.BL;

public class GetPropertyDetailsDto
{
    public string NameOfProperty { get; set; } = string.Empty;
    public string RatingOverroll { get; set; } = string.Empty;
    public int NumOfReview { get; set; }
    public string CityNmae { get; set; } = string.Empty;
    public string CountryNmae { get; set; } = string.Empty;
    public List<string>? Imgs { get; set; }
    public string UserName { get; set; } = string.Empty;
    public string UserImage { get; set; } = string.Empty;
    public int MaxNumOfGust { get; set; }
    public int BedRoomCount { get; set; }
    public decimal PricePerNight { get; set; }
    public string PropertyDescription { get; set; } = string.Empty;
    public ICollection<AmintsDTO> Aminties { get; set; } =new List<AmintsDTO>();    


}





public class AmintsDTO
{

    public string AmintiesName { get; set; } = string.Empty;
    public string Icon { get; set; } = string.Empty;

}
