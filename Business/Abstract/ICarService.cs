using System;
using System.Collections.Generic;
using System.Text;
using CoreLayer.Utilities.Results.Abstract;
using Entities.Concrete;
using Entities.DTOs;

namespace Business.Abstract
{
   public interface ICarService
   {
       // data listeleyenler
        IDataResult<List<NCar>> GetAll();
        /*
        IDataResult<List<NCar>> GetCarsByBrandId(int id);

        IDataResult<List<NCar>> GetCarsByColorId(int id);
        */

        IDataResult<List<CarDetailDto>> GetCarsByBrandId(int id);

        IDataResult<List<CarDetailDto>> GetCarsByColorId(int id);

        IDataResult<List<CarDetailDto>> GetCarById(int id);

        IDataResult<List<CarDetailDto>> GetCarDetails();
    

        IDataResult<List<NCar>> GetByDailyPrice(decimal min, decimal max);
       // IDataResult<NCar> GetCarsById(int id);

        // voidler

        IResult AddCar(NCar car);
        IResult Delete(NCar car);
        IResult Update(NCar car);


   }
}
