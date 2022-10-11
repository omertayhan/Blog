using Microsoft.EntityFrameworkCore;

namespace Blog.Models
{
    public class BlogContext : DbContext
    {
        public BlogContext(DbContextOptions <BlogContext> options) : base(options)
        {

        }
        public DbSet<Users> Users { get; set;}
        public DbSet<Blog> Blogs { get; set;}
        public DbSet<Category> Categories { get; set;}
    }
}
