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
            Id = x,
            Description = $"Description {x}",
            Date = DateTime.Now.AddDays(x),
            Image = $"http://miapi.com/image/{x}",
            UserId = x * 2
        });

        public IEnumerable<Post> Get()
        {
            return list;
        }

        public async Task<Post> GetById(int id)
        {
            await Task.Delay(1000);
            return list.FirstOrDefault(p => p.Id.Equals(id));
        }

        public async Task<Post> Save(Post model)
        {
            await Task.Delay(1000);
            model.Id = list.OrderBy(l => l.Id).Last().Id + 1;
            list.Append(model);
            return model;
        }

        public async Task<bool> Update(Post model)
        {
            var post = await GetById(model.Id);
            return true;
        }

        public async Task<bool> Delete(int id)
        {
            var post = await GetById(id);
            return true;
        }
    }
}
