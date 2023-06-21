using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Airbnb.DAl;

public class Category
{
    [Key]

    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public IEnumerable<Property> CategoryProperties { get; set; } = new List<Property>();
}
