using System;
using System.Collections.Generic;
using System.Text;
using CoreLayer.DataAccess;
using DataAccess.Abstract;
using DataAccess.CoreLayer;
using Entities.Concrete;
using Entities.DTOs;
using System.Linq.Expressions;
using System.Linq;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfCustomerDAL:EfEntityRepositoryBase<NCustomer,ProjectDBContext>,ICustomerDAL
    {
        public List<CustomerDetailDto> GetCustomerDetails()
        {
            using (ProjectDBContext context1 = new ProjectDBContext())
            {
                var result = from u in context1.TBL_USERS
                    join c in context1.TBL_CUSTOMERS
                        on u.Id equals c.UserId
                    select new CustomerDetailDto
                    {
                        UserId = u.Id,
                        FirstName = u.FirstName,
                        LastName = u.LastName,
                        CompanyName = c.CompanyName
                    };
                return result.ToList();
            }
        }
    }
}
