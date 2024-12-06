using Microsoft.AspNetCore.Mvc;
using ValorantHubAPI.API.Services;
using ValorantHubAPI.Data.Entities;

namespace ValorantHubAPI.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IAuthService _authService;
        public AuthController(IAuthService authService)
        {
            _authService = authService;
        }

        [HttpPost]
        public IActionResult Post([FromBody] UserEntity user)
        {
            var token = _authService.Login(user);

            if(token == null)
            {
                return BadRequest();
            }
            
            return Ok(token);
        }
    }
}
