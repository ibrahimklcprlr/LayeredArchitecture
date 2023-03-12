﻿using Core.Utilities.Results;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface ICategoryServices
    {
       IDataResult<List<Category>> GetAll();
       IDataResult<Category> GetById(int id);
    }
}
