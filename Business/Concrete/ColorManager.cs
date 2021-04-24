using System;
using System.Collections.Generic;
using System.Text;
using Business.Abstract;
using Business.Constants;
using CoreLayer.Utilities.Results.Abstract;
using CoreLayer.Utilities.Results.Concrete;
using DataAccess.Abstract;
using Entities.Concrete;

namespace Business.Concrete
{
    public class ColorManager:IColorService
    {
        private IColorDAL _iColorDal;

        public ColorManager(IColorDAL colorDal)
        {
            _iColorDal = colorDal;

        }
        public IDataResult<List<NColor>> GetAll()
        {
            return new SuccessDataResult<List<NColor>>(_iColorDal.GetAll(),Messages.ColorsListed);
        }

        public IDataResult<NColor> GetById(int ColorId)
        {
         
           return new SuccessDataResult<NColor>(_iColorDal.Get(c => c.Id == ColorId));
        }

        public IResult UpdateColor(NColor color)
        {
            _iColorDal.Update(color);
            return  new SuccessResult(Messages.ColorUpdated);
        }

        public IResult DeleteColor(NColor color)
        { 

            _iColorDal.Delete(color);
            return new SuccessResult(Messages.ColorDeleted);
        }

        public IResult AddColor(NColor color)
        {
            _iColorDal.Add(color);
            return new SuccessResult(Messages.ColorAdded);
        }
    }
}
