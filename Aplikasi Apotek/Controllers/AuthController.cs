using Aplikasi_Apotek.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Text;

namespace Aplikasi_Apotek.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private IConfiguration _config;
        private readonly ApotekContext _apotekContext;
        public AuthController(IConfiguration configuration, ApotekContext apotekContext)
        {
            _config = configuration;
            _apotekContext = apotekContext;
        }

        private User AuthenticateUser(User user)
        {
            User _user = null;
            var data = _apotekContext.User.FirstOrDefault(u => u.Username == user.Username);
            if (data != null && data.Password == user.Password)
            {
                _user = data;
            }
            return _user;
        }

        private string GenerateToken(User users)
        {
            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["Jwt:Key"]));
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

            var token = new JwtSecurityToken(_config["Jwt:Issuer"], _config["Jwt:Audience"], null, expires: DateTime.Now.AddMinutes(1), signingCredentials: credentials);

            return new JwtSecurityTokenHandler().WriteToken(token);
        }

        [AllowAnonymous]
        [HttpPost]
        public IActionResult Login([FromBody] UserLoginRequest loginRequest)
        {
            IActionResult response = Unauthorized();
            var user = new User { Username = loginRequest.Username, Password = loginRequest.Password };
            var authenticatedUser = AuthenticateUser(user);
            if (authenticatedUser != null)
            {
                var token = GenerateToken(authenticatedUser);
                response = Ok(new { token = token, data = authenticatedUser });

                
            }
            return response;
        }
    }
}
