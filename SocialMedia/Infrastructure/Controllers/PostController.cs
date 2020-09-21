using Microsoft.AspNetCore.Mvc;
using SocialMedia.Core.Entities;
using SocialMedia.Core.Interfaces;
using System.Threading.Tasks;

namespace SocialMedia.Infrastructure.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PostController : ControllerBase
    {
        private readonly IPostRepository _postRepository;

        public PostController(IPostRepository postRepository)
        {
            this._postRepository = postRepository;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var lista = await this._postRepository.Get();
            return Ok(lista);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var post = await this._postRepository.GetById(id);
            return Ok(post);
        }

        [HttpPost]
        public async Task<ActionResult> Post(Post post)
        {
            post.Id = 0;
            var model = await this._postRepository.Save(post);
            return Ok(model);
        }
    }
}