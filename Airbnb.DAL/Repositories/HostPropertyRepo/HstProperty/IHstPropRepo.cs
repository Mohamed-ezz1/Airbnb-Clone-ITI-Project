
using Airbnb.DAL.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Airbnb.DAL;

public interface IHstPropRepo
{
    bool Add(Property property);
    Property? GetPropertyById(Guid id);
    bool Update(Property property);
    //comment
    int SaveChanges();

    User? GetUserById(string id);

    Property? GetPropertyToDeleteById(Guid id);

}
