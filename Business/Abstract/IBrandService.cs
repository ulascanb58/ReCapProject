using System;
using System.Collections.Generic;
using System.Text;
using Entities.Concrete;

namespace Business.Abstract
{
    public interface IBrandService
    {
        List<NBrand> GetAll();
        NBrand GetById(int BrandId);

        void AddBrand(NBrand brand);
        void DeleteBrand(NBrand brand);
        void UpdateBrand(NBrand brand);
    }
}
