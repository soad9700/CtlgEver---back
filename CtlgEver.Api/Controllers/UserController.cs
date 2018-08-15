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
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;

namespace CtlgEver.Api.Controllers
{
    [Route("controller")]
    [RequireHttps]
    public class UserController : Controller
    {
        // private readonly IConfiguration _config;
        private readonly IJwtSettings _jwtSettings;
        private readonly IUserService _userService;

        public UserController(IUserService userService, IJwtSettings jwtSettings)
        {
            _jwtSettings = jwtSettings;
            _userService = userService;
        }
        [Authorize]
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

        [HttpPost("register")]
        public async Task<IActionResult> Register([FromBody] CreateUser command)
        {
            command.Email = command.Email.ToLower ();
            if (await _userService.GetByEmailAsync (command.Email)!=null)
                ModelState.AddModelError ("Email", "Email is already taken.");
            if (!ModelState.IsValid)
                return BadRequest (ModelState);
            try {
                await _userService.RegisterAsync (command.Email, command.Password, command.Name, command.Surname);
                return StatusCode (201);
            } catch (Exception e) {
                return BadRequest (e.Message);
            }
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