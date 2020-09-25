namespace SocialMedia.Infrastructure.Controllers
{
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.Extensions.Configuration;
    using Microsoft.IdentityModel.Tokens;
    using SocialMedia.Core.Entities;
    using SocialMedia.Core.Interfaces.Service;
    using System;
    using System.IdentityModel.Tokens.Jwt;
    using System.Security.Claims;
    using System.Text;
    using System.Threading.Tasks;

    [Route("api/[controller]")]
    [ApiController]
    public class TokenController : ControllerBase
    {
        private readonly IConfiguration configuration;
        private readonly ISecurityService securityService;

        public TokenController(IConfiguration configuration, ISecurityService securityService)
        {
            this.configuration = configuration;
            this.securityService = securityService;
        }

        [HttpPost]
        public async Task<IActionResult> Authentication(UserLogin userLogin)
        {
            var validation = await ValidUser(userLogin);
            if (validation.Item1)
            {
                return Ok(new { token = GenerateToken(validation.Item2) });
            }
            return BadRequest();
        }

        private async Task<(bool, Security)> ValidUser(UserLogin login)
        {
            var user = await securityService.GetLoginByCredentials(login);
            return (user != null, user);
        }

        private string GenerateToken(Security security)
        {
            // Header
            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(configuration["Authentication:SecretKey"]));
            var credentials = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
            var header = new JwtHeader(credentials);
            //claims
            var claims = new[] {
                new Claim(ClaimTypes.Name, security.UserName),
                new Claim(ClaimTypes.Email, security.UserSM),
                new Claim(ClaimTypes.Role, security.Rol.ToString()),
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
