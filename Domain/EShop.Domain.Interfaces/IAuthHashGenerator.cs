using System.Security.Claims;
using Microsoft.IdentityModel.Tokens;

namespace EShop.Domain.Interfaces
{
    public interface IAuthHashGenerator
    {
        public void CreatePasswordHash(string password, out byte[] passwordHash, out byte[] passwordSalt);
        public bool VerifyPasswordHash(string password, byte[] passwordHash, byte[] passwordSalt);

        public string? GenerateJwt(ClaimsIdentity claims);
    }
}

