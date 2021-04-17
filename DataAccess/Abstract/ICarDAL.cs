using System;
using System.Collections.Generic;
using System.Text;
using Entities.Concrete;

namespace DataAccess.Abstract
{
    public interface ICarDAL
    {
        List<NCar> GetAll();

        void Add(NCar car);
        void Update(NCar car);
        void Delete(NCar car);
        List<NCar> GetById(int Id);
    }
}
