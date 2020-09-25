namespace SocialMedia.Infrastructure.Controllers
{
    using System.Collections.Generic;
    using System.Net;
    using System.Threading.Tasks;
    using AutoMapper;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;
    using Newtonsoft.Json;
    using SocialMedia.Core.Custom;
    using SocialMedia.Core.Dto;
    using SocialMedia.Core.Entities;
    using SocialMedia.Core.Interfaces.Service;
    using SocialMedia.Core.QueryFilter;
    using SocialMedia.Infrastructure.Interfaces;
    using SocialMedia.Infrastructure.Response;

    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class PublishController : ControllerBase
    {
        private readonly IPublicationService _publishservice;
        private readonly IMapper _mapper;
        private readonly IUriService unitService;

        public PublishController(IPublicationService _publishservice, IMapper mapper, IUriService unitService)
        {
            this._publishservice = _publishservice;
            this._mapper = mapper;
            this.unitService = unitService;
        }

        [HttpGet(Name = nameof(Get))]
        [ProducesResponseType(typeof(ApiResponse<IEnumerable<PublicationDto>>), (int)HttpStatusCode.OK)]
        public IActionResult Get([FromQuery] GetQueryFilter queryFilter)
        {
            var list = this._publishservice.GetWithFilters(queryFilter: queryFilter);

            var metadata = new MetaData {
                TotalCount = list.TotalCount,
                PageSize = list.PageSize,
                CurrentPage = list.Current,
                TotalPages = list.TotalPage,
                HasNextPage = list.HasNextPage,
                HasPreviusPage = list.HasPreviusPage,
                NextPageUrl = list.HasNextPage
                            ? $"{unitService.GetPostPaginaUrl(queryFilter, Url.RouteUrl(nameof(Get))).ToString()}?PageNumber={list.Current+1}" : string.Empty,
                PreviousPageUrl = list.HasPreviusPage
                            ? $"{unitService.GetPostPaginaUrl(queryFilter, Url.RouteUrl(nameof(Get))).ToString()}?PageNumber={list.Current-1}" : string.Empty,
            };
            Response.Headers.Add("x-pagination", JsonConvert.SerializeObject(metadata));
            return Ok(new ApiResponse<IEnumerable<PublicationDto>>(_mapper.Map<IEnumerable<PublicationDto>>(list)) { MetaData = metadata });
        }

        [HttpGet("{id}")]
        [ProducesResponseType(typeof(ApiResponse<PublicationDto>), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> GetById(int id)
        {
            var publish = await this._publishservice.GetById(id);
            return Ok(new ApiResponse<PublicationDto>(_mapper.Map<PublicationDto>(publish)));
        }

        [HttpPost]
        [ProducesResponseType(typeof(ApiResponse<PublicationDto>), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> Post(PublicationDto publication)
        {
            publication.Id = 0;
            var publish = await this._publishservice.Save(_mapper.Map<Publication>(publication));
            return Ok(new ApiResponse<PublicationDto>(_mapper.Map<PublicationDto>(publish)));
        }

        [HttpPut("{id}")]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        public async Task<IActionResult> Put(int id, [FromBody] PublicationDto publication)
        {
            publication.Id = id;
            var response = await this._publishservice.Update(_mapper.Map<Publication>(publication));
            //return Ok(new ApiResponse<bool>(response));
            if (response)
                return Ok();
            return BadRequest();
        }

        [HttpDelete("{id}")]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        public async Task<IActionResult> Delete(int id)
        {
            var response = await this._publishservice.Delete(id);
            //return Ok(new ApiResponse<bool>(response));
            if (response)
                return Ok();
            return BadRequest();
        }
    }
}
