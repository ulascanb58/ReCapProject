using CoreLayer.Utilities.Results.Abstract;
using CoreLayer.Utilities.Security.JWT;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Abstract
{
   public interface IAuthService
    {
        IDataResult<NUser> Register(UserForRegisterDto userForRegisterDto, string password);
        IDataResult<NUser> Login(UserForLoginDto userForLoginDto);
        IResult UserExists(string email);
        IDataResult<AccessToken> CreateAccessToken(NUser user);
    }
}
