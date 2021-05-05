using System;
using System.Collections.Generic;
using System.Text;

namespace CoreLayer.Utilities.Security.JWT
{
    public class NTokenOptions
    {
        public string Audience { get; set; }
        public string Issuer { get; set; }
        public int AccessTokenExpiration { get; set; }
        public string SecurityKey { get; set; }
    }
}
