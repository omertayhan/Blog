using Blog.Models;
using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;

namespace Blog.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly BlogContext _context;

        public HomeController(ILogger<HomeController> logger, BlogContext context)
        {
            _logger = logger;
            _context = context;
        }
        public IActionResult Index()
        {
            var list = _context.Blogs.Where(x => x.IsPublish == true).OrderByDescending(x => x.CreateTime).ToList();
            foreach (var blog in list)
            {
                blog.User = _context.Users.Find(blog.UserId);
            }
            return View(list);
        }
        public IActionResult PostDetail(int Id)
        {
            var list = _context.Blogs.Find(Id);
            list.User = _context.Users.Find(list.UserId);
            list.ImagePath = "/img/" + list.ImagePath;
            return View(list);
        }
        public IActionResult About()
        {
            return View();
        }
        public IActionResult Contact()
        {
            return View();
        }
        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}