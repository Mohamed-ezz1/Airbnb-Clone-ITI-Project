using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Airbnb.DAl;

public class Rule
{
    public int Id { get; set; }
    public string RuleName { get; set; } = string.Empty;
    public IEnumerable<PropertyRule> RuleProperty { get; set; } = new List<PropertyRule>();
}
