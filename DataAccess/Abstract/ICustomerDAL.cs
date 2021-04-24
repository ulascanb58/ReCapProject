using System;
using System.Collections.Generic;
using System.Text;
using DataAccess.CoreLayer;
using Entities.Concrete;
using Entities.DTOs;

namespace DataAccess.Abstract
{
   public interface ICustomerDAL:IEntityRepository<NCustomer>
    {
        List<CustomerDetailDto> GetCustomerDetails();
    }
}
