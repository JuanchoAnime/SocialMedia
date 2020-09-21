namespace SocialMedia.Infrastructure.Controllers
{
    using AutoMapper;
    using Microsoft.AspNetCore.Mvc;
    using SocialMedia.Core.Dto;
    using SocialMedia.Core.Entities;
    using SocialMedia.Core.Interfaces;
    using SocialMedia.Infrastructure.Response;
    using System.Collections.Generic;
    using System.Threading.Tasks;

    [Route("api/[controller]")]
    [ApiController]
    public class PublishController : ControllerBase
    {
        private readonly IPublicationService _publishservice;
        private readonly IMapper _mapper;

        public PublishController(IPublicationService _publishservice, IMapper mapper)
        {
            this._publishservice = _publishservice;
            this._mapper = mapper;
        }

        [HttpGet]
        public ActionResult Get()
        {
            var list = this._publishservice.Get();
            return Ok(new ApiResponse<IEnumerable<PublicationDto>>(_mapper.Map<IEnumerable<PublicationDto>>(list)));
        }

        [HttpGet("{id}")]
        public async Task<ActionResult> GetById(int id)
        {
            var publish = await this._publishservice.GetById(id);
            return Ok(new ApiResponse<PublicationDto>(_mapper.Map<PublicationDto>(publish)));
        }

        [HttpPost]
        public async Task<ActionResult> Post(PublicationDto publication)
        {
            publication.Id = 0;
            var publish = await this._publishservice.Save(_mapper.Map<Publication>(publication));
            return Ok(new ApiResponse<PublicationDto>(_mapper.Map<PublicationDto>(publish)));
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> Put(int id, [FromBody] PublicationDto publication)
        {
            publication.Id = id;
            var response = await this._publishservice.Update(_mapper.Map<Publication>(publication));
            //return Ok(new ApiResponse<bool>(response));
            if (response)
                return Ok();
            return BadRequest();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            var response = await this._publishservice.Delete(id);
            //return Ok(new ApiResponse<bool>(response));
            if (response)
                return Ok();
            return BadRequest();
        }
    }
}
