using CoreLayer.Utilities.Results.Abstract;
using System;
using System.Collections.Generic;
using System.Text;
using Entities.Concrete;
using Entities.DTOs;

namespace Business.Abstract
{
    public interface ICustomerService
    {
        IResult Add(NCustomer customer);
        IResult Delete(NCustomer customer);
        IResult Update(NCustomer customer);
        IDataResult<List<NCustomer>> GetAll();
        IDataResult<NCustomer> GetById(int customerid);
        IDataResult<List<CustomerDetailDto>> GetCustomerDetails();
    }
}
