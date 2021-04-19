using System;
using System.Collections.Generic;
using System.Text;
using Entities.Concrete;

namespace Business.Abstract
{
   public interface ICarService
   {
        List<NCar> GetAll();

        List<NCar> GetCarsByBrandId(int id);

        List<NCar> GetCarsByColorId(int id);

        

       

        void AddCar(NCar car);



   }
}
