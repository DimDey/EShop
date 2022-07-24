using System.Security.Claims;
using EShop.Domain.Core;
using EShop.Domain.Interfaces;
using Microsoft.Extensions.Logging;

namespace EShop.Infrastructure.Auth
{
    public class AuthService : IAuthService
    {
        private readonly IRepository<User> _users;
        private readonly IAuthHashGenerator _tokenGenerator;
        private readonly ILogger<AuthService> _logger;
        public AuthService(IRepository<User> users, IAuthHashGenerator generator, ILogger<AuthService> logger)
        {
            _users = users;
            _tokenGenerator = generator;
            _logger = logger;
        }

        public async Task<string?> Authenticate(UserDto request)
        {
            var user = await _users.Get(x => x.UserName == request.Username);
            if (user == null)
            {
                return null;
            }

            if (!_tokenGenerator.VerifyPasswordHash(request.Password, user.PasswordHash, user.PasswordSalt))
            {
                return null;
            }
            // TODO: Make ClaimsHelper class
            ClaimsIdentity claims = new ClaimsIdentity(new Claim[]
            {
                new Claim(ClaimTypes.Name, user.UserName)
            });

            return _tokenGenerator.GenerateJwt(claims);
        }

        public async Task<User?> Register(UserDto request)
        {
            var user = await _users.Get(x => x.UserName == request.Username);
            if (user is not null)
            {
                return null;
            }

            _tokenGenerator.CreatePasswordHash(request.Password, out byte[] passwordHash, out byte[] passwordSalt);

            var entity = new User()
            {
                UserName = request.Username,
                PasswordHash = passwordHash,
                PasswordSalt = passwordSalt
            };
            await _users.Add(entity);

            return entity;
        }
    }
    
}

