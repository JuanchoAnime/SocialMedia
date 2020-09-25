namespace SocialMedia.Infrastructure.Repositories
{
    using System.Threading.Tasks;
    using SocialMedia.Core.Interfaces;
    using SocialMedia.Core.Interfaces.Repository;
    using SocialMedia.Infrastructure.Data;

    public class UnitOfWork : IUnitOfWork
    {
        private SocialMediaContext _context;
        private IPublishRepository _publishRepository;
        private IUserRepository _userRepository;
        private IComentaryRepository _commentRepository;
        private ISecurityRepository _securityRepository;

        public UnitOfWork(SocialMediaContext context) {
            this._context = context;
        }

        public IPublishRepository PostRepository
        {
            get
            {
                _publishRepository = _publishRepository ?? new PublishRepository(this._context);
                return _publishRepository;
            }
        }

        public ISecurityRepository SecurityRepository
        {
            get
            {
                _securityRepository = _securityRepository ?? new SecurityRepository(this._context);
                return _securityRepository;
            }
        }

        public IUserRepository UserRepository
        {
            get
            {
                _userRepository = _userRepository ?? new UserRepository(this._context);
                return _userRepository;
            }
        }

        public IComentaryRepository ComentaryRepository
        {
            get
            {
                _commentRepository = _commentRepository ?? new ComentaryRepository(this._context);
                return _commentRepository;
            }
        }


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
