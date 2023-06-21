using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Airbnb.DAl;

public class PropertyImage
{
    public int Id { get; set; }
    public Guid PropertyId { get; set; }
    public Property? Property { get; set; } 
    public string Image { get; set; } = string.Empty;
    public int UserId { get; set; }
    public User? User { get; set; }
    public DateTime CreatedDate { get; set; }
}
