using Microsoft.AspNetCore.Mvc;
using MusicHubLoginService.Dto;
using MusicHubLoginService.Services;
using System;

namespace MusicHubLoginService.Controllers
{
    [ApiController]
    [Route("api/user")]
    public class LoginController : Controller
    {
        private readonly ILoginService _loginService;

        public LoginController(ILoginService loginService)
        {
            _loginService = loginService;
        }

        [HttpPost]
        [Route("create")]
        public IActionResult CreateUser([FromBody] CreateUserRequest request)
        {
            var user = _loginService.CreateUser(request.Username, request.Password);
            return new CreatedResult("", user);
        }

        [HttpPost]
        [Route("login")]
        public IActionResult Login([FromBody] LoginRequest request)
        {
            Console.WriteLine(request);
            var loggedIn = _loginService.Login(request);
            Console.WriteLine(loggedIn);
            return new AcceptedResult($"api/user/login", loggedIn);
        }


    }
}
