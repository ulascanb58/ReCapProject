using System;
using System.Collections.Generic;
using System.Text;
using CoreLayer.DataAccess;
using CoreLayer.Entities.Concrete;
using DataAccess.Abstract;
using Entities.Concrete;
using System.Linq;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfUserDAL:EfEntityRepositoryBase<NUser,ProjectDBContext>,IUserDAL
    {
        public List<NOperationClaim> GetClaims(NUser user)
        {
            using (var context = new ProjectDBContext())
            {
                var result = from operationClaim in context.TBL_OPERATION_CLAIMS
                             join userOperationClaim in context.TBL_USER_OPERATION_CLAIMS
                                 on operationClaim.Id equals userOperationClaim.OperationClaimId
                             where userOperationClaim.UserId == user.Id
                             select new NOperationClaim { Id = operationClaim.Id, Name = operationClaim.Name };
                return result.ToList();

            }
        }
    }
}
