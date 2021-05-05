using System;
using System.Collections.Generic;
using System.Text;
using CoreLayer.Entities.Concrete;
using CoreLayer.Utilities.Results.Abstract;
using Entities.Concrete;

namespace Business.Abstract
{
   public interface IUserService
    {
        IDataResult<List<NUser>> GetAll();
        IDataResult<NUser> GetById(int userid);
       
        IResult Add(NUser user);
        IResult Update(NUser user);
        IResult Delete(NUser user);
         List<NOperationClaim> GetClaims(NUser user);
        NUser GetByMail(string email);
    }
}
