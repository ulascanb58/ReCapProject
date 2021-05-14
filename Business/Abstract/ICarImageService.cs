using CoreLayer.Utilities.Results.Abstract;
using Entities.Concrete;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Abstract
{
    public interface ICarImageService
    {
        IDataResult<List<NCarImage>> GetAll();
        IDataResult<NCarImage> GetById(int id);
        IDataResult<List<NCarImage>> GetByCarId(int id);
        IResult Add(IFormFile file, NCarImage carImage);
        IResult Update(IFormFile file, NCarImage carImage);
        IResult Delete(NCarImage carImage);

    }
}
