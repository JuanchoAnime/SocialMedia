namespace SocialMedia.Infrastructure.Repositories
{
    using SocialMedia.Core.Entities;
    using SocialMedia.Core.Interfaces;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    public class PostRepository : IPostRepository
    {
        private readonly IEnumerable<Post> list = Enumerable.Range(1, 10).Select(x => new Post()
        {
            IdPost = x,
            Description = $"Description {x}",
            Date = DateTime.Now.AddDays(x),
            Image = $"http://miapi.com/image/{x}",
            UserId = x * 2
        });

        public async Task<IEnumerable<Post>> Get()
        {
            await Task.Delay(1000);
            return list;
        }

        public async Task<Post> GetById(int id)
        {
            await Task.Delay(1000);
            return list.FirstOrDefault(p => p.IdPost.Equals(id));
        }

        public async Task<Post> Save(Post model)
        {
            await Task.Delay(1000);
            model.IdPost = list.OrderBy(l => l.IdPost).Last().IdPost + 1;
            list.Append(model);
            return model;
        }
    }
}
