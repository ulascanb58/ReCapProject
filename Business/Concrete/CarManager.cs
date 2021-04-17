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

        public void Add(NCar car)
        {
            _iCarDal.Add(car);
        }

        public void Delete(NCar car)
        {
            _iCarDal.Delete(car);
        }

        public void Update(NCar car)
        {
            _iCarDal.Update(car);
        }

        

        public List<NCar> GetById(int id)
        {
            return _iCarDal.GetById(id);
        }
    }
}
