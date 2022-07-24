using System.Text;
using Microsoft.IdentityModel.Tokens;

namespace EShop.Infrastructure.Auth
{
    public class JwtOptions
    {
        public string Issuer { get; set; }
        public string Audience { get; set; }
        public string TokenKey { get; set; }
        public int Lifetime { get; set; }
    }
}

