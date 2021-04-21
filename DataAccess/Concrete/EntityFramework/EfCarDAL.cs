using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using CoreLayer.DataAccess;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using Microsoft.EntityFrameworkCore;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfCarDAL:EfEntityRepositoryBase<NCar,ProjectDBContext>,ICarDAL
    {
        public List<CarDetailDto> GetCarDetails()
        {
            using (ProjectDBContext context1 = new ProjectDBContext())
            {
                var result = from ca in context1.TBLCARS
                    join br in context1.TBLBRANDS
                        on ca.BrandId equals br.Id
                    join co in context1.TBLCOLORS
                        on ca.ColorId equals co.Id
                    select new CarDetailDto
                    {
                        BrandName = br.BrandName,
                        CarDescription = ca.Description,
                        CarId = ca.Id,
                        ColorName = co.ColorName
                    };
                return result.ToList();
            }
        }
    }
}
