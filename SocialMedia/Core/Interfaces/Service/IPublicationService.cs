namespace SocialMedia.Core.Interfaces.Service
{
    using SocialMedia.Core.Entities;
    using SocialMedia.Core.Interfaces.Generic;
    using SocialMedia.Core.QueryFilter;
    using System.Collections.Generic;

    public interface IPublicationService : IGenericService<Publication>
    {
        IEnumerable<Publication> GetWithFilters(GetQueryFilter queryFilter);
    }
}