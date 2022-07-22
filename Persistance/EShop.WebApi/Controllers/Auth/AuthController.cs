using EShop.Domain.Core;
using EShop.Domain.Interfaces;
using EShop.Infrastructure.Auth;
using Microsoft.AspNetCore.Mvc;

namespace EShop.Persistance.WebApi.Controllers.Auth
{
    
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : Controller
    {
        private readonly IRepository<User> _users;
        private readonly AuthHandler _handler;
        
        public AuthController(IRepository<User> users, AuthHandler handler)
        {
            _users = users;
            _handler = handler;
        }
        
        [HttpPost("register")]
        public ActionResult<User> RegisterMethod(UserDto request)
        {
            var entity = _handler.RegisterUser(request);
            if (entity == null)
            {
                return BadRequest("Error");
            }

            return Ok(entity);
        }

        [HttpPost("login")]
        public ActionResult<User> AuthMethod(UserDto request)
        {
            var entity = _handler.AuthenticateUser(request);
            if (entity == null)
            {
                return BadRequest("Error auth");
            }

            return Ok(entity);
        }
    }
}
