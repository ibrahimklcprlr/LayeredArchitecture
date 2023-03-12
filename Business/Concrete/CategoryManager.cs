using Business.Abstract;
using Business.Constants;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class CategoryManager : ICategoryServices
    {
        ICategoryDal _categorydal;
        public CategoryManager(ICategoryDal categorydal)
        {
            _categorydal = categorydal;
        }

        public IDataResult<List<Category>> GetAll()
        {
            return new SuccessDataResult<List<Category>>(_categorydal.GetAll(),Messages.CategoryListed);
        }

        public IDataResult<Category> GetById(int id)
        {
            return new SuccessDataResult<Category>(_categorydal.Get(c => c.CategoryId == id));
        }
    }
}
