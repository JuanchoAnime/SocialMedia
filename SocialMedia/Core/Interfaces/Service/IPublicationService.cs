namespace SocialMedia.Core.Interfaces.Service
{
    using SocialMedia.Core.Custom;
    using SocialMedia.Core.Entities;
    using SocialMedia.Core.Interfaces.Generic;
    using SocialMedia.Core.QueryFilter;

    public interface IPublicationService : IGenericService<Publication>
    {
        PageList<Publication> GetWithFilters(GetQueryFilter queryFilter);
    }
}