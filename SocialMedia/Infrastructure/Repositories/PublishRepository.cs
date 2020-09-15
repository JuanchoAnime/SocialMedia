using Microsoft.EntityFrameworkCore;
using SocialMedia.Core.Entities;
using SocialMedia.Core.Interfaces;
using SocialMedia.Infrastructure.Data;
using System;
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
    }
}
