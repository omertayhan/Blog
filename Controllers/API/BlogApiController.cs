using Blog.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Blog.Controllers.API
{
    [Route("api/[controller]")]
    [ApiController]
    public class BlogApiController : ControllerBase
    {
        private readonly BlogContext _context;

        public BlogApiController(BlogContext context)
        {
            _context = context;
        }

        // GET: api/BlogApi
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Users>>> GetUsers()
        {
            return await _context.Users.ToListAsync();
        }

        // GET: api/BlogApi/16
        [HttpGet("{id}")]
        public async Task<ActionResult<Models.Blog>> GetPost(int? id)
        {
            var blog = await _context.Blogs.FindAsync(id);

            if (blog == null)
            {
                return NotFound();
            }

            return blog;
        }
    }
}