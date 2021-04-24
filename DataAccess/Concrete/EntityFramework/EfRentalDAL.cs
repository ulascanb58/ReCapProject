using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using CoreLayer.DataAccess;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using System.Linq.Expressions;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfRentalDAL:EfEntityRepositoryBase<NRental,ProjectDBContext>,IRentalDAL
    {
        public List<RentalDetailDto> GetRentalDetails(Expression<Func<NRental, bool>> filter = null)
        {
            using (ProjectDBContext context1 = new ProjectDBContext())
            {
                var result = from ca in context1.TBL_CARS
                    join re in context1.TBL_RENTALS
                        on ca.Id equals  re.CarId
                    join cu in context1.TBL_CUSTOMERS
                        on re.CustomerId equals cu.CustomerId
                        join u in context1.TBL_USERS
                            on cu.UserId equals  u.Id
                    select new RentalDetailDto
                    {
                        CarName = ca.Description,
                        CompanyName = cu.CompanyName,
                        RentDate = re.RentDate,
                        ReturnDate = re.ReturnDate
                        
                    };
                return result.ToList();
            }
        }
    }
}
