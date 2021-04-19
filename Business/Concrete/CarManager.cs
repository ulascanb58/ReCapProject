using System;
using System.Collections.Generic;
using System.Text;
using Business.Abstract;
using DataAccess.Abstract;
using Entities.Concrete;

namespace Business.Concrete
{
    public class CarManager:ICarService
    {
        ICarDAL _iCarDal;

        public CarManager(ICarDAL carDal)
        {
            _iCarDal = carDal;
        }


        public List<NCar> GetAll()
        {
            return _iCarDal.GetAll();
        }

        public List<NCar> GetCarsByBrandId(int id)
        {
            return _iCarDal.GetAll(p => p.BrandId == id);
        }

        public List<NCar> GetCarsByColorId(int id)
        {
            return _iCarDal.GetAll(p => p.ColorId == id);
        }

        
        public void AddCar(NCar car)
        {
            if (car.Description.Length > 2 && car.DailyPrice > 0)
            {
                _iCarDal.Add(car);
            }
            else
            {
                Console.WriteLine("Araba ismi minimum 2 karakter olmalıdır, Araba günlük fiyatı 0'dan büyük olmalıdır.");
            }
        }
    }
}
