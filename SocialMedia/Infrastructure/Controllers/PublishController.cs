using Microsoft.AspNetCore.Mvc;
using SocialMedia.Core.Interfaces;
using System.Threading.Tasks;

namespace SocialMedia.Infrastructure.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PublishController : ControllerBase
    {
        private readonly IPublishRepository _publishRepository;

        public PublishController(IPublishRepository publishRepository)
        {
            this._publishRepository = publishRepository;
        }

        [HttpGet]
        public async Task<ActionResult> Get()
        {
            var list = await this._publishRepository.Get();
            return Ok(list);

        }
    }
}
