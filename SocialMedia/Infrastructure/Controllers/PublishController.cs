using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using SocialMedia.Core.Dto;
using SocialMedia.Core.Entities;
using SocialMedia.Core.Interfaces;
using SocialMedia.Infrastructure.Response;
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
            return Ok(new ApiResponse<IEnumerable<PublicationDto>>(_mapper.Map<IEnumerable<PublicationDto>>(list)));
        }

        [HttpGet("{id}")]
        public async Task<ActionResult> GetById(int id)
        {
            var publish = await this._publishRepository.GetById(id);
            return Ok(new ApiResponse<PublicationDto>(_mapper.Map<PublicationDto>(publish)));
        }

        [HttpPost]
        public async Task<ActionResult> Post(PublicationDto publication)
        {
            publication.IdPublication = 0;
            var publish = await this._publishRepository.Save(_mapper.Map<Publication>(publication));
            return Ok(new ApiResponse<PublicationDto>(_mapper.Map<PublicationDto>(publish)));
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> Put(int id, [FromBody] PublicationDto publication)
        {
            publication.IdPublication = id;
            var response = await this._publishRepository.Update(_mapper.Map<Publication>(publication));
            return Ok(new ApiResponse<bool>(response));
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            var response = await this._publishRepository.Delete(id);
            return Ok(new ApiResponse<bool>(response));
        }
    }
}
