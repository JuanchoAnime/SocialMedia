namespace SocialMedia.Infrastructure.Repositories
{
    using Microsoft.EntityFrameworkCore;
    using SocialMedia.Core.Entities;
    using SocialMedia.Core.Interfaces;
    using SocialMedia.Infrastructure.Data;
    using System.Collections.Generic;
    using System.Threading.Tasks;

    public class UserRepository : IUserRepository
    {
        private readonly SocialMediaContext _context;

        public UserRepository(SocialMediaContext context)
        {
            this._context = context;
        }

        public Task<bool> Delete(int id)
        {
            throw new System.NotImplementedException();
        }

        public async Task<IEnumerable<User>> Get()
        {
            var posts = await this._context.User.ToListAsync();
            return posts;
        }

        public async Task<User> GetById(int id)
        {
            var post = await this._context.User.FirstOrDefaultAsync(p => p.IdUser.Equals(id));
            return post;
        }

        public Task<User> Save(User model)
        {
            throw new System.NotImplementedException();
        }

        public Task<bool> Update(User model)
        {
            throw new System.NotImplementedException();
        }
    }
}
