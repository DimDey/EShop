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
        private readonly IAuthService _auth;
        
        public AuthController(IRepository<User> users, IAuthService auth)
        {
            _users = users;
            _auth = auth;
        }
        
        [HttpPost("register")]
        public async Task<ActionResult<User>> Register(UserDto request)
        {
            var entity = await _auth.Register(request);
            if (entity == null)
            {
                return BadRequest("Error");
            }

            return Ok(entity);
        }

        [HttpPost("login")]
        public async Task<ActionResult<User>> Authenticate(UserDto request)
        {
            var entity = await _auth.Authenticate(request);
            if (entity == null)
            {
                return BadRequest("Error auth");
            }

            return Ok(entity);
        }
    }
}
