using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;

namespace Airbnb.DAl;

public class User: IdentityUser
{
    public string FirstName { get; set; } = string.Empty;
    public string LasttName { get; set; } = string.Empty;
    public string UserType { get; set; } = string.Empty;
    public string About { get; set; } = string.Empty;
    public IEnumerable<PropertyImage> UserPropertyImages { get; set; } = new List<PropertyImage>();
    public IEnumerable<Booking> UserBookings { get; set; } = new List<Booking>();
    public IEnumerable<Property> UserProperties { get; set; } = new List<Property>();
}
