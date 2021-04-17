using System;
using System.Collections.Generic;
using System.Text;
using Entities.Concrete;

namespace Business.Abstract
{
   public interface ICarService
   {
        List<NCar> GetAll();
        void Add(NCar car);
        void Delete(NCar car);

        void Update(NCar car);
        List<NCar> GetById(int id);

   }
}
