using SocialMedia.Core.Dto;
using SocialMedia.Core.Entities;

namespace SocialMedia.Infrastructure.Mapper
{
    public class AutoMapperProfile : AutoMapper.Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<PublicationDto, Publication>();
            CreateMap<Publication, PublicationDto>();
        }
    }
}
