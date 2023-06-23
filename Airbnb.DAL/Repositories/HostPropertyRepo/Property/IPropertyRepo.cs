
using Airbnb.DAL.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Airbnb.DAL;

public interface IPropertyRepo
{
    void Add(Property property);
    Property? GetPropertyById(Guid id);
    void Update(Property property);

    int SaveChanges();
}
