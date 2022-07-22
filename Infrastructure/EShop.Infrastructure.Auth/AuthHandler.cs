using EShop.Domain.Core;
using EShop.Domain.Interfaces;

namespace EShop.Infrastructure.Auth
{
    public class AuthHandler : IAuthHandler
    {
        private readonly IRepository<User> _users;
        private readonly IAuthHashGenerator _hashGenerator;
        public AuthHandler(IRepository<User> users, IAuthHashGenerator generator)
        {
            _users = users;
            _hashGenerator = generator;
        }

        public string? AuthenticateUser(UserDto request)
        {
            // TODO: REFACTOR TO ASYNC METHOD
            var user = _users.Get(x => x.UserName == request.Username).FirstOrDefault();

            if (!_hashGenerator.VerifyPasswordHash(request.Password, user.PasswordHash, user.PasswordSalt))
            {
                return null;
            }

            // TODO: ADD JWT TOKEN GENERATOR
            return "ok";
        }

        public User? RegisterUser(UserDto request)
        {
            var user = _users.Get(x => x.UserName == request.Username).FirstOrDefault();

            _hashGenerator.CreatePasswordHash(request.Password, out byte[] passwordHash, out byte[] passwordSalt);

            var entity = new User()
            {
                UserName = request.Username,
                PasswordHash = passwordHash,
                PasswordSalt = passwordSalt
            };
            _users.Add(entity);

            return entity;
        }
    }
    
}

