using System;
using System.Collections.Generic;
using System.Text;
using Business.Abstract;
using Business.Constants;
using CoreLayer.Utilities.Results.Abstract;
using CoreLayer.Utilities.Results.Concrete;
using DataAccess.Abstract;
using DataAccess.Concrete.EntityFramework;
using Entities.Concrete;
using Entities.DTOs;

namespace Business.Concrete
{
    public class CustomerManager :ICustomerService
    {
        private ICustomerDAL _iCustomerDal;
        public CustomerManager(ICustomerDAL customerDal)
        {
            _iCustomerDal = customerDal;
        }
        public IResult Add(NCustomer customer)
        {
            _iCustomerDal.Add(customer);
            return  new SuccessResult(Messages.CustomerAdded);
        }

        public IResult Delete(NCustomer customer)
        {
            _iCustomerDal.Delete(customer);
            return  new SuccessResult(Messages.CustomerDeleted);
        }

        public IResult Update(NCustomer customer)
        {
            _iCustomerDal.Update(customer);
            return new SuccessResult(Messages.CustomerUpdated);
        }

        public IDataResult<List<NCustomer>> GetAll()
        {
            

            return new SuccessDataResult<List<NCustomer>>(_iCustomerDal.GetAll());


        }

        public IDataResult<NCustomer> GetById(int customerid)
        {
            return new SuccessDataResult<NCustomer>(_iCustomerDal.Get(c => c.CustomerId == customerid));
        }

        public IDataResult<List<CustomerDetailDto>> GetCustomerDetails()
        {
            return new SuccessDataResult<List<CustomerDetailDto>>(_iCustomerDal.GetCustomerDetails());
        }
    }
}
