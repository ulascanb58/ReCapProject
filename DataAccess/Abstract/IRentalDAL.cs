using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using DataAccess.CoreLayer;
using Entities.Concrete;
using Entities.DTOs;

namespace DataAccess.Abstract
{
    public  interface IRentalDAL:IEntityRepository<NRental>
    {
        List<RentalDetailDto> GetRentalDetails(Expression<Func<NRental, bool>> filter = null);
    }
}
