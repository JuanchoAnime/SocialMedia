namespace SocialMedia.Infrastructure.Repositories
{
    using SocialMedia.Core.Entities;
    using SocialMedia.Core.Interfaces;
    using SocialMedia.Infrastructure.Data;

    public class PublishRepository : CrudRepository<Publication>, IPublishRepository
    {
        public PublishRepository(SocialMediaContext context) : base(context)
        {
        }
    }
}
