namespace SocialMedia.Core.Interfaces.Repository
{
    using SocialMedia.Core.Entities;
    using SocialMedia.Core.Interfaces.Generic;
    using System.Collections.Generic;
    using System.Threading.Tasks;

    public interface IPublishRepository : IDataRepository<Publication>
    {
        Task<IEnumerable<Publication>> GetPostsByUser(int userId);
    }
}
