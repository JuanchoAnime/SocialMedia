namespace SocialMedia.Core.Interfaces
{
    using SocialMedia.Core.Interfaces.Repository;
    using System;
    using System.Threading.Tasks;

    public interface IUnitOfWork : IDisposable
    {
        public IPublishRepository PostRepository { get; }

        public IUserRepository UserRepository { get; }

        public IComentaryRepository ComentaryRepository { get; }

        public ISecurityRepository SecurityRepository { get; }

        void SaveChanges();

        Task SaveChangesAsync();
    }
}
