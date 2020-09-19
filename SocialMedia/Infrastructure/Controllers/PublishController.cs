using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using SocialMedia.Core.Dto;
using SocialMedia.Core.Entities;
using SocialMedia.Core.Interfaces;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SocialMedia.Infrastructure.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PublishController : ControllerBase
    {
        private readonly IPublishRepository _publishRepository;
        private readonly IMapper _mapper;

        public PublishController(IPublishRepository publishRepository, IMapper mapper)
        {
            this._publishRepository = publishRepository;
            this._mapper = mapper;
        }

        [HttpGet]
        public async Task<ActionResult> Get()
        {
            var list = await this._publishRepository.Get();
            return Ok(_mapper.Map<IEnumerable<PublicationDto>>(list));
        }

        [HttpGet("{id}")]
        public async Task<ActionResult> GetById(int id)
        {
            var publish = await this._publishRepository.GetById(id);
            return Ok(_mapper.Map<PublicationDto>(publish));
        }

        [HttpPost]
        public async Task<ActionResult> Post(PublicationDto publication)
        {
            publication.IdPublication = 0;
            var publish = await this._publishRepository.Save(_mapper.Map<Publication>(publication));
            return Ok(_mapper.Map<PublicationDto>(publish));
        }
    }
}
