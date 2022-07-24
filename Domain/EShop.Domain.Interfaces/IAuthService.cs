using EShop.Domain.Core;

namespace EShop.Domain.Interfaces
{
    public interface IAuthService
    {
        public Task<string?> Authenticate(UserDto request);
        public Task<User?> Register(UserDto request);
    }
}