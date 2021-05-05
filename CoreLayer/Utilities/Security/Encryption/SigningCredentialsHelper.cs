using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.Text;

namespace CoreLayer.Utilities.Security.Hashing
{
    public class SigningCredentialsHelper
    {

        public static SigningCredentials CreateSigningCredentials(SecurityKey securityKey)
        {
            //kullanıcı adı parole bir credential
            return new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha512Signature);
        }
    }
}
