namespace SocialMedia.Infrastructure.Repositories
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using Microsoft.EntityFrameworkCore;
    using SocialMedia.Core.Entities;
    using SocialMedia.Core.Interfaces.Repository;
    using SocialMedia.Infrastructure.Data;

    public class PublishRepository : CrudRepository<Publication>, IPublishRepository
    {
        public PublishRepository(SocialMediaContext context) : base(context)
        {
        }

        public async Task<IEnumerable<Publication>> GetPostsByUser(int userId)
        {
            return await this._entity.Where(post => post.IdUser.Equals(userId)).ToListAsync();
        }
    }
}
