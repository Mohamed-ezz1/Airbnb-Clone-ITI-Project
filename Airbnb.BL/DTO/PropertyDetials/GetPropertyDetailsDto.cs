using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Airbnb.BL;

public class PropertyDetialsDto
{
    public string? NameOfProperty { get; set; }
    public string? RatingOverroll { get; set; }
    public int NumOfReview { get; set; }
    public string? CityNmae { get; set; }
    public string? CountryNmae { get; set; }
    public List<String>? Imgs { get; set; }
    public string? UserName { get; set; }
    public string? UserImage { get; set; }
    public int MaxNumOfGust { get; set; }
    public int BedRoomCount { get; set; }
    public decimal PricePerNight { get; set; }// 
    public string? PropertyDescription { get; set; }
    public List<AmintsDTO>? Aminties { get; set; }


}





public class AmintsDTO
{

    public string? AmintiesName { get; set; }
    public string? Icon { get; set; }

}
