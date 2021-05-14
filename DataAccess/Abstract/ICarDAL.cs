using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using DataAccess.CoreLayer;
using Entities.Concrete;
using Entities.DTOs;

namespace DataAccess.Abstract
{
    public interface ICarDAL:IEntityRepository<NCar>
    {
        //  List<CarDetailDto> GetCarDetails();
        List<CarDetailDto> GetCarDetails(Expression<Func<CarDetailDto, bool>> filter = null);
    }
}
