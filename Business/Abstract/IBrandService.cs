using System;
using System.Collections.Generic;
using System.Text;
using CoreLayer.Utilities.Results.Abstract;
using Entities.Concrete;

namespace Business.Abstract
{
    public interface IBrandService
    {
       IDataResult<List<NBrand>> GetAll();
       IDataResult<NBrand> GetById(int BrandId);

        IResult AddBrand(NBrand brand);
        IResult DeleteBrand(NBrand brand);
        IResult UpdateBrand(NBrand brand);
    }
}
