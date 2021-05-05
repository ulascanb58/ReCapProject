using System;
using System.Collections.Generic;
using System.Text;
using CoreLayer.Entities.Concrete;
using DataAccess.CoreLayer;
using Entities.Concrete;

namespace DataAccess.Abstract
{
    public interface IUserDAL:IEntityRepository<NUser>
    {
        List<NOperationClaim> GetClaims(NUser user);
    }
}
