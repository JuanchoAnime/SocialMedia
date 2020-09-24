namespace SocialMedia.Infrastructure.Controllers
{
    using System;
    using System.Collections.Generic;
    using System.IdentityModel.Tokens.Jwt;
    using System.Linq;
    using System.Security.Claims;
    using System.Text;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Http;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.Extensions.Configuration;
    using Microsoft.IdentityModel.Tokens;
    using SocialMedia.Core.Entities;

    [Route("api/[controller]")]
    [ApiController]
    public class TokenController : ControllerBase
    {
        private readonly IConfiguration configuration;

        public TokenController(IConfiguration configuration)
        {
            this.configuration = configuration;
        }

        [HttpPost]
        public IActionResult Authentication(UserLogin userLogin) 
        {
            if (ValidUser(userLogin))
            {
                return Ok(new { token = GenerateToken() });
            }
            return NotFound();
        }

        private bool ValidUser(UserLogin login) 
        {
            return true;
        }

        private string GenerateToken()
        {
            // Header
            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(configuration["Authentication:SecretKey"]));
            var credentials = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
            var header = new JwtHeader(credentials);
            //claims
            var claims = new[] {
                new Claim(ClaimTypes.Name, "Judas"),
                new Claim(ClaimTypes.Email, "judas3991@gmail.com"),
                new Claim(ClaimTypes.Role, "Admin"),
            };
            //payload
            var payLoad = new JwtPayload(
                configuration["Authentication:Issuer"],
                configuration["Authentication:Audience"],
                claims, DateTime.Now, DateTime.UtcNow.AddDays(2)
            );

            var token = new JwtSecurityToken(header, payLoad);
            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}
