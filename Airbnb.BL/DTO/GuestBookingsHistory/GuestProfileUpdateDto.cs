using Airbnb.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Airbnb.BL;

public class GuestProfileUpdateDto
{

    public string UserId { get; set; }
    public User User { get; set; }=new User();
    public string? FirstName { get; set; } =  User?.FirstName;
    public string LastName { get; set; }
    public string Email { get; set; }
    public string PhoneNumber { get; set; }
    public string About { get; set; }
}
