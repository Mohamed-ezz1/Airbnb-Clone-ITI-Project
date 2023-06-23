using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Airbnb.DAL;

public class City
{
    [Key]

    public int Id { get; set; }
    public string CityName { get; set; } = string.Empty;
    public int? CounrtyId { get; set; }
    public Country? Country { get; set; } 
    public IEnumerable<Property> CityProperties { get; set; } = new List<Property>();

}
