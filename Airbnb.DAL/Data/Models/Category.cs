using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Airbnb.DAl;

public class Category
{
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public IEnumerable<Property> CategoryProperties { get; set; } = new List<Property>();
}
