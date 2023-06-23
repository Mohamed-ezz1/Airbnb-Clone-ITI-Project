using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

    namespace Airbnb.DAL
    {
    public interface IUserDetailsRepositories
    {
        User GetUesrInfo(string userId);
        UserType GetUserType(string Id);
        User GuestProfileRead(string userId);
        int SaveChanges();

    }
}
