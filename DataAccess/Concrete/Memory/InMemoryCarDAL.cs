using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;

namespace DataAccess.Concrete
{
   public class InMemoryCarDAL:ICarDAL
    {
        List<NCar> _cars;

        public InMemoryCarDAL()
        {
            _cars = new List<NCar>
            {
                new NCar{Id = 1,BrandId = 1, ColorId = 2, DailyPrice = 25000, Description = "Şahin",ModelYear = 1998},
                new NCar{Id = 2,BrandId = 1, ColorId = 2, DailyPrice = 23000, Description = "Kartal",ModelYear = 1997},
                new NCar{Id = 3,BrandId = 1, ColorId = 2, DailyPrice = 22000, Description = "Doğan",ModelYear = 1995},
                new NCar{Id = 4,BrandId = 2, ColorId = 2, DailyPrice = 40000, Description = "Clio",ModelYear = 2004},
                new NCar{Id = 5,BrandId = 2, ColorId = 2, DailyPrice = 61000, Description = "Megane",ModelYear = 2007}
            };
            
        }
        public List<NCar> GetAll()
        {
            return _cars.ToList();
        }

        public List<NCar> GetAll(Expression<Func<NCar, bool>> filter = null)
        {
            throw new NotImplementedException();
        }

        public NCar Get(Expression<Func<NCar, bool>> filter)
        {
            throw new NotImplementedException();
        }

        public void Add(NCar car)
        {
            _cars.Add(car);
        }

        public void Update(NCar car)
        {
            NCar carToUpdate = _cars.SingleOrDefault(p => p.Id == car.Id);
            carToUpdate.ModelYear = car.ModelYear;
            carToUpdate.ColorId = car.ColorId;
            carToUpdate.DailyPrice = car.DailyPrice;
            carToUpdate.Id = car.Id;
            carToUpdate.BrandId = car.BrandId;
            carToUpdate.ModelYear = car.ModelYear;
            Console.WriteLine(carToUpdate.ModelYear);

        }

        public void Delete(NCar car)
        {
            NCar carToDelete = _cars.SingleOrDefault(p => p.Id == car.Id);
            _cars.Remove(carToDelete);
        }

        public List<CarDetailDto> GetCarDetails()
        {
            throw new NotImplementedException();
        }

        public List<NCar> GetById(int Id)
        {
            return _cars.Where(p => p.Id == Id).ToList();
        }

    }
}
