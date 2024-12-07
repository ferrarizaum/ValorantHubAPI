using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ValorantHubAPI.API.Services;
using ValorantHubAPI.Data.Entities;

namespace ValorantHubAPI.API.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : Controller
    {
        private readonly IUserService _userService;
        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var users = _userService.GetUsers();
            return Ok(users);
        }

        [HttpPost]
        public IActionResult Post([FromBody] UserEntity user)
        {
            var newUser = _userService.PostUser(user);
            return Ok(newUser);
        }

        //add put route

        [HttpDelete]
        public IActionResult Delete(string userName)
        {
            var removedUser = _userService.RemoveUser(userName);
            return Ok(removedUser);
        }
    }
}
