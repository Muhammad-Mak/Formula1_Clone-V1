using AngularF1APIv2.Context;
using AngularF1APIv2.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace AngularF1APIv2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PostsController : ControllerBase
    {
        private readonly AppDbContext _context;

        public PostsController(AppDbContext context)
        {
            _context = context;
        }


        [HttpGet]
        public async Task<ActionResult<List<Post>>> GetPosts()
        {
            return await _context.Posts
                .OrderByDescending(p => p.DateTime)
                .ToListAsync();
        }
        [HttpPost]
        public async Task<ActionResult> CreatePost(PostDTO post)
        {
            Post myPost = new Post
            {
                DateTime = DateTime.Now,
                PostDetails = post.PostDetails,
                Username = post.Username,
            };
            _context.Posts.Add(myPost);
            await _context.SaveChangesAsync();

            return Ok( new { id = myPost.PostID });
        }
    }
}
