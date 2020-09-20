using Microsoft.EntityFrameworkCore;
using SocialMedia.Core.Entities;
using SocialMedia.Core.Interfaces;
using SocialMedia.Infrastructure.Data;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SocialMedia.Infrastructure.Repositories
{
    public class PublishRepository : IPublishRepository
    {
        private readonly SocialMediaContext _context;

        public PublishRepository(SocialMediaContext context)
        {
            this._context = context;
        }

        public async Task<IEnumerable<Publication>> Get()
        {
            var posts = await this._context.Publication.ToListAsync();
            return posts;
        }

        public async Task<Publication> GetById(int id)
        {
            var post = await this._context.Publication.FirstOrDefaultAsync(p => p.IdPublication.Equals(id));
            return post;
        }

        public async Task<Publication> Save(Publication model)
        {
            this._context.Publication.Add(model);
            await this._context.SaveChangesAsync();
            return model;
        }

        public async Task<bool> Update(Publication model)
        {
            var post = await GetById(model.IdPublication);
            post.Description = model.Description;
            post.Date = model.Date;
            post.Image = model.Image;
            this._context.Publication.Update(post);
            return 0 < await this._context.SaveChangesAsync();
        }

        public async Task<bool> Delete(int id)
        {
            var post = await GetById(id);
            this._context.Publication.Remove(post);
            return 0 < await this._context.SaveChangesAsync();
        }
    }
}
