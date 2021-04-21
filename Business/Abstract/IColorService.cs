using System;
using System.Collections.Generic;
using System.Text;
using Entities.Concrete;

namespace Business.Abstract
{
    public interface IColorService
    {
        List<NColor> GetAll();
        NColor GetById(int ColorId);

        void UpdateColor(NColor color);
        void DeleteColor(NColor color);
        void AddColor(NColor color);

    }
}
