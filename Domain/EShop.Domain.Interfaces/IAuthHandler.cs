using EShop.Domain.Core;

namespace EShop.Domain.Interfaces
{
    public interface IAuthHandler
    {
        public string? AuthenticateUser(UserDto request);
        public User? RegisterUser(UserDto request);
    }
}