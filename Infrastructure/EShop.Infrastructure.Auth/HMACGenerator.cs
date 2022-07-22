using System.Security.Cryptography;
using EShop.Domain.Interfaces;

namespace EShop.Infrastructure.Auth
{
    public class HMACGenerator : IAuthHashGenerator
    {
        public void CreatePasswordHash(string password, out byte[] passwordHash, out byte[] passwordSalt)
        {
            using (var hmac = new HMACSHA512())
            {
                passwordSalt = hmac.Key;
                var passwordBytes = System.Text.Encoding.UTF8.GetBytes(password);
                passwordHash = hmac.ComputeHash(passwordBytes);
            }
        }

        public bool VerifyPasswordHash(string password, byte[] passwordHash, byte[] passwordSalt)
        {
            using (var hmac = new HMACSHA512(passwordSalt))
            {
                var passwordBytes = System.Text.Encoding.UTF8.GetBytes(password);
                var computedHash = hmac.ComputeHash(passwordBytes);
                return computedHash.SequenceEqual(passwordHash);
            }
        }
    }
}

