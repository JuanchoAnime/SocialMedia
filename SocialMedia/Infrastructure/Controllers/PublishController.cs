using Microsoft.AspNetCore.Mvc;
using SocialMedia.Core.Dto;
using SocialMedia.Core.Entities;
using SocialMedia.Core.Interfaces;
using System.Linq;
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
            return Ok(list.Select(p => new PublicationDto { 
                Date = p.Date, 
                Description = p.Description, 
                IdPublication = p.IdPublication, 
                IdUser = p.IdUser, 
                Image = p.Image 
            }));
        }

        [HttpGet("{id}")]
        public async Task<ActionResult> GetById(int id)
        {
            var publish = await this._publishRepository.GetById(id);
            return Ok(new PublicationDto { 
                Date = publish.Date, 
                Description = publish.Description, 
                Image = publish.Image, 
                IdUser = publish.IdUser, 
                IdPublication = publish.IdPublication 
            });
        }

        [HttpPost]
        public async Task<ActionResult> Post(PublicationDto publication)
        {
            publication.IdPublication = 0;
            var publish = await this._publishRepository.Save(new Publication { 
                IdPublication = publication.IdPublication, 
                IdUser = publication.IdUser, 
                Image = publication.Image, 
                Description = publication.Description, 
                Date = publication.Date 
            });
            return Ok(new PublicationDto
            {
                Date = publish.Date,
                Description = publish.Description,
                Image = publish.Image,
                IdUser = publish.IdUser,
                IdPublication = publish.IdPublication
            });
        }
    }
}
