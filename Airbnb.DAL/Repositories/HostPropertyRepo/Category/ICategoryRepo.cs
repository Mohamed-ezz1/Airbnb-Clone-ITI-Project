﻿
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Airbnb.DAL;

public interface ICategoryRepo
{
    IEnumerable<Category> GetCategory();
    int SaveChanges();

}
