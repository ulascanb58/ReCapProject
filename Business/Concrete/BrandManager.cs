using System;
using System.Collections.Generic;
using System.Text;
using Business.Abstract;
using Business.Constants;
using Business.ValidationRules.FluentValidation;
using CoreLayer.Aspects.Autofac.Validation;
using CoreLayer.Utilities.Results.Abstract;
using CoreLayer.Utilities.Results.Concrete;
using DataAccess.Abstract;
using Entities.Concrete;

namespace Business.Concrete
{
   public class BrandManager:IBrandService
   {
       private IBrandDAL _iBrandDal;

       public BrandManager(IBrandDAL brandDal)
       {
           _iBrandDal = brandDal;

       }
        public IDataResult<List<NBrand>> GetAll()
        {
            return new SuccessDataResult<List<NBrand>>(_iBrandDal.GetAll());
        }

        public IDataResult<NBrand>GetById(int BrandId)
        {
            return new SuccessDataResult<NBrand>(_iBrandDal.Get(b => b.Id == BrandId)); 
        }

        [ValidationAspect(typeof(BrandValidator))]
        public IResult AddBrand(NBrand brand)
        {

            
            if (brand.BrandName.Length > 2)
            {
                _iBrandDal.Add(brand);
                return new SuccessResult(Messages.BrandAdded);
            }
            else
            {
                return new ErrorResult(Messages.BrandNameInvalid);
            }
            

        }

        public IResult  DeleteBrand(NBrand brand)
        {

            _iBrandDal.Delete(brand);
            return  new SuccessResult(Messages.BrandDeleted);
        }

        [ValidationAspect(typeof(BrandValidator))]
        public IResult UpdateBrand(NBrand brand)
        {
            _iBrandDal.Update(brand);
            return  new SuccessResult(Messages.BrandUpdated);
        }
   }
}
