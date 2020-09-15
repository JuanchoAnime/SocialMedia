namespace SocialMedia.Infrastructure.Repositories
{
    using SocialMedia.Core.Entities;
    using SocialMedia.Core.Interfaces;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    public class PostRepository: IPostRepository
    {
        public async Task<IEnumerable<Post>> Get() 
        {
            await Task.Delay(1);
                
            return Enumerable.Range(1, 10).Select( x => new Post() { 
                IdPost = x,
                Description = $"Description {x}",
                Date = DateTime.Now.AddDays(x),
                Image = $"http://miapi.com/image/{x}",
                UserId = x*2
            });
        }
    }
}
