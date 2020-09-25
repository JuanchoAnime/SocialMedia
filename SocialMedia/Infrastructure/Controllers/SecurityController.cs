namespace SocialMedia.Infrastructure.Controllers
{
    using AutoMapper;
    using Microsoft.AspNetCore.Mvc;
    using SocialMedia.Core.Dto;
    using SocialMedia.Core.Entities;
    using SocialMedia.Core.Interfaces.Service;
    using System.Threading.Tasks;

    [Route("api/[controller]")]
    [ApiController]
    public class SecurityController : ControllerBase
    {
        private readonly ISecurityService securityService;
        private readonly IMapper mapper;

        public SecurityController(ISecurityService securityService, IMapper mapper)
        {
            this.securityService = securityService;
            this.mapper = mapper;
        }

        [HttpPost]
        public async Task<IActionResult> Post(SecurityDto security)
        {
            var user = await securityService.Save(mapper.Map<SecurityDto, Security>(security));
            user.Password = string.Empty;
            return Ok(mapper.Map< Security, SecurityDto>(user));
        }
    }
}
