using System.Threading.Tasks;
using CtlgEver.Infrastructure.Create;
using CtlgEver.Infrastructure.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace CtlgEver.Api.Controllers
{
    [Route("controller")]
    public class UserController : Controller
    {
        private readonly IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpGet("name")]
        public async Task<IActionResult> Index () {
            await Task.CompletedTask;
            return Json ("Aplikacja dziala");
        }

        [HttpPost]
        public async Task<IActionResult> Register([FromBody] CreateUser command)
        {
            await _userService.RegisterAsync(command.Name, command.Surname, command.Email, command.Password);
            return StatusCode(201);
        }
    }
}