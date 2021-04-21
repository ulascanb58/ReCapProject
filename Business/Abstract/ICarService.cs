using System;
using System.Collections.Generic;
using System.Text;
using Entities.Concrete;
using Entities.DTOs;

namespace Business.Abstract
{
   public interface ICarService
   {
        List<NCar> GetAll();

        List<NCar> GetCarsByBrandId(int id);

        List<NCar> GetCarsByColorId(int id);

        List<CarDetailDto> GetCarDetails();

        List<NCar> GetByDailyPrice(decimal min, decimal max);
        NCar GetCarsById(int id);



        void AddCar(NCar car);
        void Delete(NCar car);
        void Update(NCar car);


   }
}
