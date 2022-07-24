using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;
using EShop.Domain.Interfaces;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;

namespace EShop.Infrastructure.Auth
{
    public class TokenGenerator : IAuthHashGenerator
    {
        private readonly JwtOptions _options;
        private readonly ILogger<TokenGenerator> _logger;
        public TokenGenerator(IOptions<JwtOptions> options, ILogger<TokenGenerator> logger)
        {
            _options = options.Value;
            _logger = logger;
        }
        
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

        public string? GenerateJwt(ClaimsIdentity claims)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            _logger.LogError("ISSUER: " + _options.Issuer);
            _logger.LogError("AUDIENCE: " + _options.Audience);
            _logger.LogError("TOKENKEY: " + _options.TokenKey);
            var tokenKey = System.Text.Encoding.ASCII.GetBytes(_options.TokenKey);
            var tokenSalt = new SymmetricSecurityKey(tokenKey);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Issuer = _options.Issuer,
                Audience = _options.Audience,
                Subject = claims,
                Expires = DateTime.UtcNow.AddMinutes(_options.Lifetime),
                SigningCredentials = new SigningCredentials(tokenSalt, SecurityAlgorithms.HmacSha256)
            };

            var token = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(token);
        }
    }
}

