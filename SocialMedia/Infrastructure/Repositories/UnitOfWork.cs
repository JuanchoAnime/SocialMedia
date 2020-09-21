namespace SocialMedia.Infrastructure.Repositories
{
    using System.Threading.Tasks;
    using SocialMedia.Core.Interfaces;
    using SocialMedia.Core.Interfaces.Repository;
    using SocialMedia.Infrastructure.Data;

    public class UnitOfWork : IUnitOfWork
    {
        private readonly SocialMediaContext _context;
        private readonly IPublishRepository _publishRepository;
        private readonly IUserRepository _userRepository;
        private readonly IComentaryRepository _commentRepository;

        public UnitOfWork(SocialMediaContext context) { 
            this._context = context;
        }

        public IPublishRepository PostRepository => _publishRepository ?? new PublishRepository(this._context);

        public IUserRepository UserRepository => _userRepository ?? new UserRepository(this._context);

        public IComentaryRepository ComentaryRepository => _commentRepository ?? new ComentaryRepository(this._context);


        public void Dispose()
        {
            if (this._context != null)
                this._context.Dispose();
        }

        public void SaveChanges()
        {
            this._context.SaveChanges();
        }

        public async Task SaveChangesAsync()
        {
            await this._context.SaveChangesAsync();
        }
    }
}
