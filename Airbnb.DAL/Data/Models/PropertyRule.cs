using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Airbnb.DAL;

public class PropertyRule
{
    [Key]

    public int RuleId { get; set; }
    public Rule? Rule { get; set; }
    public Guid PropertyId { get; set; }
    public Property? Property { get; set; }
}
