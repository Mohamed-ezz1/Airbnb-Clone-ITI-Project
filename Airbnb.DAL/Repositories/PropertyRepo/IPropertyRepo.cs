using Airbnb.DAl;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace Airbnb.DAL;

public interface IPropertyRepo
{
    IEnumerable<Property> GetAllProps();
    IEnumerable<Category> GetAllCategs();
    IEnumerable<UserType> GetUser();


    Category? GetCategoryById(int id);
}
