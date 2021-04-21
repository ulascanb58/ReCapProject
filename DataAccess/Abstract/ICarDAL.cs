using System;
using System.Collections.Generic;
using System.Text;
using DataAccess.CoreLayer;
using Entities.Concrete;
using Entities.DTOs;

namespace DataAccess.Abstract
{
    public interface ICarDAL:IEntityRepository<NCar>
    {
        List<CarDetailDto> GetCarDetails();
    }
}
