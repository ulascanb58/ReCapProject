using System;
using System.Collections.Generic;
using System.Text;
using Business.Abstract;
using Business.Constants;
using Business.ValidationRules.FluentValidation;
using CoreLayer.Aspects.Autofac.Validation;
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

        [ValidationAspect(typeof(ColorValidator))]
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

        [ValidationAspect(typeof(ColorValidator))]
        public IResult AddColor(NColor color)
        {
            _iColorDal.Add(color);
            return new SuccessResult(Messages.ColorAdded);
        }
    }
}
