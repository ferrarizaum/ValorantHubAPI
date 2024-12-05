﻿using Microsoft.AspNetCore.Mvc;
using ValorantHubAPI.API.Services;
using ValorantHubAPI.Data.Entities;

namespace ValorantHubAPI.API.Controllers
{
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
    }
}
