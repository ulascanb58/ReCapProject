using CoreLayer.Entities.Concrete;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace CoreLayer.Utilities.Security.JWT
{
   public interface ITokenHelper
    {
        AccessToken CreateToken(NUser user, List<NOperationClaim> operationClaims);

    }
}
