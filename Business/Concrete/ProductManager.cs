using Business.Abstract;
using Business.BusinessAspects.Autofac;
using Business.Constants;
using Business.ValidationRules.FluentValidation;
using Core.Aspects.Autofac.Caching;
using Core.Aspects.Autofac.Performance;
using Core.Aspects.Autofac.Transaction;
using Core.Aspects.Autofac.Validation;
using Core.CrossCuttingConcerns.Validation;
using Core.Utilities.Business;
using Core.Utilities.Results;
using DataAccess.Abstract;
using DataAccess.Concrete;
using Entities.Concrete;
using Entities.DTOs;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class ProductManager : IProductService
    {
        IProductDal _productdal;
        ICategoryServices _categoryServices;
        public ProductManager(IProductDal productdal, ICategoryServices categoryServices)
        {
            _productdal = productdal;
           _categoryServices = categoryServices;
        }
        [SecuredOperation("product.add,admin")]
        [ValidationAspect(typeof(ProductValidator))]
        //[CacheRemoveAspect("IProductService.Get")]
        public IResult Add(Product product)
        {
            var result = BusinessRules.Run(CheckIfProductCountCategoryCorrect(product.ProductId), CheckIfProductNameExists(product.ProductName),CheckcategoryLimitExceded());
            if (result!=null)
            {
               return result;
            }
            _productdal.Add(product);
            return new SuccessResult(Messages.ProductAdded);


        }
        private IResult CheckIfProductNameExists(string productName)
        {
            var result = _productdal.GetAll(c => c.ProductName == productName).Any();
            if (result)
            {
                return new ErrorResult(Messages.ProductNameAlreadyExist);
            }
            return new SuccessResult();
        }

        private IResult CheckIfProductCountCategoryCorrect(int categoryId)
        {
            var result = _productdal.GetAll(p => p.CategoryId == categoryId).Count;
            if (result >= 15)
            {
                return new ErrorResult(Messages.ProductCountOfcategoryError);
            }
            return new SuccessResult();
        }
        [CacheAspect]
        public IDataResult<List<Product>> GetAll()
        {
            if (DateTime.Now.Hour == 3)
            {
                return new ErrorDataResult<List<Product>>(Messages.MaintenanceTime);
            }
            return new DataResult<List<Product>>(_productdal.GetAll(), true, Messages.ProducListed);
        }
        [CacheAspect]
        public IDataResult<Product> GetProduct(int id)
        {
            return new DataResult<Product>(_productdal.Get(c => c.ProductId == id), true);
        }

        public IDataResult<List<ProductDetailDto>> GetProductDetails()
        {
            return new DataResult<List<ProductDetailDto>>(_productdal.GetProductDetails(), true);
        }
        [ValidationAspect(typeof(ProductValidator))]
        [CacheRemoveAspect("IProductService.Get")]
        public IResult Update(Product product)
        {
            throw new NotImplementedException();
        }
        private IResult CheckcategoryLimitExceded()
        {
            var result = _categoryServices.GetAll();
            if (result.Data.Count>15)
            {
                return new ErrorResult(Messages.CategoryLimitExceded);
            }
            return new SuccessResult();
        }
        [TransactionScopeAspect]
        public IResult AddTransactionalTest(Product product)
        {
            throw new NotImplementedException();
        }

        public IDataResult<List<Product>> GetAllByCategory(int categoryid)
        {
            return new DataResult<List<Product>>(_productdal.GetAllByCategory(categoryid), true);
        }
    }
}
