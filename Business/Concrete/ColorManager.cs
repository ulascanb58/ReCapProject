using System;
using System.Collections.Generic;
using System.Text;
using Business.Abstract;
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
        public List<NColor> GetAll()
        {
            return _iColorDal.GetAll();
        }

        public NColor GetById(int ColorId)
        {
           ;
           return _iColorDal.Get(c => c.Id == ColorId);
        }

        public void UpdateColor(NColor color)
        {
            _iColorDal.Update(color);
        }

        public void DeleteColor(NColor color)
        { 

            _iColorDal.Delete(color);
        }

        public void AddColor(NColor color)
        {
            _iColorDal.Add(color);
        }
    }
}
