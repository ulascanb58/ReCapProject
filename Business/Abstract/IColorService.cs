using System;
using System.Collections.Generic;
using System.Text;
using Entities.Concrete;
using CoreLayer.Utilities.Results.Abstract;

namespace Business.Abstract
{
    public interface IColorService
    {
        IDataResult<List<NColor>> GetAll();
        IDataResult<NColor> GetById(int ColorId);

        IResult UpdateColor(NColor color);
        IResult DeleteColor(NColor color);
        IResult AddColor(NColor color);

    }
}
