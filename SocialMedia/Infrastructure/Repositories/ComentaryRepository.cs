namespace SocialMedia.Infrastructure.Repositories
{
    using SocialMedia.Core.Entities;
    using SocialMedia.Core.Interfaces.Repository;
    using SocialMedia.Infrastructure.Data;

    public class ComentaryRepository : CrudRepository<Comentary>, IComentaryRepository
    {
        public ComentaryRepository(SocialMediaContext context) : base(context)
        {

        }
    }
}
