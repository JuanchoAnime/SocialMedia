namespace SocialMedia.Core.Interfaces
{
    using System;
    using System.Threading.Tasks;

    public interface IUnitOfWork : IDisposable
    {
        public IPublishRepository PostRepository { get; }

        public IUserRepository UserRepository { get; }

        public IComentaryRepository ComentaryRepository { get; }

        void SaveChanges();

        Task SaveChangesAsync();
    }
}
