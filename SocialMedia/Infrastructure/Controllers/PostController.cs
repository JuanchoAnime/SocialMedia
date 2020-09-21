namespace SocialMedia.Infrastructure.Controllers
{
    using Microsoft.AspNetCore.Mvc;
    using SocialMedia.Core.Entities;
    using SocialMedia.Core.Interfaces.Repository;
    using System.Threading.Tasks;

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
        public IActionResult Get()
        {
            var lista = this._postRepository.Get();
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