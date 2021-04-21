using System;
using System.Collections.Generic;
using System.Text;
using Business.Abstract;
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
        public List<NBrand> GetAll()
        {
           return _iBrandDal.GetAll();
        }

        public NBrand GetById(int BrandId)
        {
            return _iBrandDal.Get(b => b.Id == BrandId);
        }

        public void AddBrand(NBrand brand)
        {
            _iBrandDal.Add(brand);
        }

        public void DeleteBrand(NBrand brand)
        {
            _iBrandDal.Delete(brand);
        }

        public void UpdateBrand(NBrand brand)
        {
            _iBrandDal.Update(brand);
        }
   }
}
