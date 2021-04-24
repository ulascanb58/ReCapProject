using System;
using System.Collections.Generic;
using System.Text;
using Business.Abstract;
using Business.Constants;
using CoreLayer.Utilities.Results.Abstract;
using CoreLayer.Utilities.Results.Concrete;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;

namespace Business.Concrete
{
    public class CarManager:ICarService
    {
        ICarDAL _iCarDal;

        public CarManager(ICarDAL carDal)
        {
            _iCarDal = carDal;
        }


        public IDataResult<List<NCar>> GetAll()
        {
            if (DateTime.Now.Hour==16)
            {
                return new ErrorDataResult<List<NCar>>(Messages.MaintenanceTime);
            }
            return new SuccessDataResult<List<NCar>>(_iCarDal.GetAll());
        }

        public IDataResult<List<NCar>> GetCarsByBrandId(int id)
        {
            return new SuccessDataResult<List<NCar>>(_iCarDal.GetAll(p => p.BrandId == id));  
        }

        public IDataResult<List<NCar>> GetCarsByColorId(int id)
        {
            return  new SuccessDataResult<List<NCar>>(_iCarDal.GetAll(p => p.ColorId == id));
        }


        public IDataResult<NCar> GetCarsById(int id)
        {
            return new SuccessDataResult<NCar>(_iCarDal.Get(c => c.Id == id)); 
        }

        public IResult AddCar(NCar car)
        {
            if (car.Description.Length > 2 && car.DailyPrice > 0)
            {
                _iCarDal.Add(car);
                return new SuccessResult(Messages.CarAdded);
                
            }

           ;
            return new ErrorResult(Messages.CarNameInvalid);
            
           
        }

        public IResult Delete(NCar car)
        {
            _iCarDal.Delete(car);
            return new SuccessResult(Messages.CarDeleted);
           
        }

        public IResult Update(NCar car)
        {
            _iCarDal.Update(car);
            return new SuccessResult(Messages.CarUpdated);
           
        }

        public IDataResult<List<CarDetailDto>> GetCarDetails()
        {
            return new SuccessDataResult<List<CarDetailDto>>(_iCarDal.GetCarDetails());
           
        }

        public IDataResult<List<NCar>> GetByDailyPrice(decimal min, decimal max)
        {
            return new SuccessDataResult<List<NCar>>(_iCarDal.GetAll(c => c.DailyPrice >= min && c.DailyPrice <= max)); 
        }
    }
}
