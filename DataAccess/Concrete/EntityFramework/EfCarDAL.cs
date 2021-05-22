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
    public class EfCarDAL : EfEntityRepositoryBase<NCar, ProjectDBContext>, ICarDAL
    {
        /* public List<CarDetailDto> GetCarDetails()
         {
             using (ProjectDBContext context1 = new ProjectDBContext())
             {
                 var result = from ca in context1.TBL_CARS
                     join br in context1.TBL_BRANDS
                         on ca.BrandId equals br.Id
                     join co in context1.TBL_COLORS
                         on ca.ColorId equals co.Id
                     select new CarDetailDto
                     {
                         BrandName = br.BrandName,
                         Description = ca.Description,
                         Id = ca.Id,
                         ColorName = co.ColorName,
                         ModelYear=ca.ModelYear,
                         DailyPrice=ca.DailyPrice

                     };
                 return result.ToList();
             }
         }*/
        public List<CarDetailDto> GetCarDetails(Expression<Func<CarDetailDto, bool>> filter = null)
        {
            using (ProjectDBContext context1 = new ProjectDBContext())
            {
                var result = from c in context1.TBL_CARS
                             join b in context1.TBL_BRANDS on c.BrandId equals b.brandId
                             join cl in context1.TBL_COLORS on c.ColorId equals cl.colorId
                             select new CarDetailDto
                             {
                                 CarId=c.Id,
                                 BrandId=c.BrandId,
                                 ColorId=c.ColorId,
                                 BrandName=b.BrandName,
                                 ColorName=cl.ColorName,
                                 Price=c.DailyPrice,
                                 ModelYear=c.ModelYear,
                                 Description=c.Description,
                                 ImagePath = (from carImages in context1.TBL_CARIMAGES
                                              where carImages.CarId == c.Id
                                              select carImages.ImagePath).ToList(),
                                 CarImage = (from img in context1.TBL_CARIMAGES
                                             where (c.Id == img.CarId)
                                             select new NCarImage { ImageId = img.ImageId, CarId = c.Id, Date = img.Date, ImagePath = img.ImagePath }).ToList()

                             };
                return filter == null ? result.ToList() : result.Where(filter).ToList();
            }
        }
    }
}

