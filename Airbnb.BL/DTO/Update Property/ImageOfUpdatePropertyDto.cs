using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Airbnb.BL;

public class ImageOfUpdatePropertyDto
{
    public int Id { get; set; }
    public string URL { get; set; } = string.Empty;
}
