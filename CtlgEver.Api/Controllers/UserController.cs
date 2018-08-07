using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using AutoMapper.Configuration;
using CtlgEver.Core.Domains;
using CtlgEver.Infrastructure.Create;
using CtlgEver.Infrastructure.JWT;
using CtlgEver.Infrastructure.Services.Interfaces;
using CtlgEver.Infrastructure.UserCommands;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;

namespace CtlgEver.Api.Controllers
{
    [Route("controller")]
    public class UserController : Controller
    {
        private readonly IJwtSettings _jwtSettings;
        private readonly IUserService _userService;
        private IConfiguration  _config;

        public UserController(IUserService userService, IConfiguration config, IJwtSettings jwtSettings)
        {
            _jwtSettings = jwtSettings;
            _userService = userService;
            _config = config;
        }

        [HttpGet("name")]
        public async Task<IActionResult> Index () {
            await Task.CompletedTask;
            return Json ("Aplikacja dziala");
        }

        [HttpPost ("login")]
        public async Task<IActionResult> Login ([FromBody] SignInUser command) {
            if (!ModelState.IsValid)
                return BadRequest (ModelState);
            var user = await _userService.LoginAsync (command.Email, command.Password);
            if (user == null)
                return Unauthorized ();
            var token = new TokenDto {
                Token = await GenerateToken (user, _jwtSettings)
            };
            return Ok (token);
        }

        [HttpPost]
        public async Task<IActionResult> Register([FromBody] CreateUser command)
        {
            await _userService.RegisterAsync(command.Name, command.Surname, command.Email, command.Password);
            return StatusCode(201);
        }
        private async Task<string> GenerateToken (User user, IJwtSettings jwtSettings) {
            var tokenHandler = new JwtSecurityTokenHandler ();
            var key = Encoding.ASCII.GetBytes (jwtSettings.Key);
            var tokenDescriptor = new SecurityTokenDescriptor {
                Subject = new ClaimsIdentity (new Claim[] {
                new Claim (ClaimTypes.NameIdentifier, user.UserId.ToString ()),
                new Claim (ClaimTypes.Name, user.Email),
                new Claim (ClaimTypes.Role, user.Role)
                }),
                Issuer = "",
                Expires = DateTime.Now.AddDays (jwtSettings.ExpiryDays),
                SigningCredentials = new SigningCredentials (new SymmetricSecurityKey (key),
                SecurityAlgorithms.HmacSha512Signature)
            };
            var token = tokenHandler.CreateToken (tokenDescriptor);
            return await Task.FromResult (tokenHandler.WriteToken (token));
        }

    }
}