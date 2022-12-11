using Azure.Core;
using Microsoft.AspNetCore.Mvc;
using NotedAPI.Dto;
using NotedAPI.Models;
using NotedAPI.Services.Users;

namespace NotedAPI.Controllers
{

    [ApiController]
    [Route("api/[controller]")]
    public class UserController : ControllerBase
    {
            private readonly IUserService _userService;

            public UserController(IUserService userService)
            {
               _userService = userService;
            }
            [HttpPost("register")]
            public async Task<IActionResult> Register(UserRegisterDto user)
            {
            return Ok(await _userService.Register(new User { Username = user.Username ,Email = user.Email}, user.Password));
            }
            [HttpGet("login")]
            public async Task<IActionResult> Login(string username, string password)
            {
            return Ok(await _userService.Login(username,password));
            }
    }
}
