using System.Diagnostics;
using Blog.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Blog.Controllers
{
    public class BlogController : Controller
    {
        private readonly ILogger<BlogController> _logger;
        private readonly BlogContext _context;

        public BlogController(ILogger<BlogController> logger, BlogContext context)
        {
            _logger = logger;
            _context = context;
        }

        public IActionResult BlogAdd()
        {
            ViewBag.Categories = _context.Category.Select(w =>
                new SelectListItem
                {
                    Text = w.Name,
                    Value = w.Id.ToString()
                }).ToList();
            return View();
        }

        public IActionResult BlogList()
        {
            var list = _context.Blogs.ToList();
            return View(list);
        }

        public IActionResult Publish(int id)
        {
            var blog = _context.Blogs.Find(id);
            blog.IsPublish = true;
            _context.Update(blog);
            _context.SaveChanges();
            return RedirectToAction("BlogList");
        }

        public async Task<IActionResult> Save(Models.Blog model)
        {
            if (model != null)
            {
                var file = Request.Form.Files.First();
                string savePath = Path.Combine("C:","masters","Blog","Blog","wwwroot","img");
                var fileName = $"{DateTime.Now.Date:MMddHHmmSS}.{file.FileName.Split(".").Last()}";
                var fileUrl = Path.Combine(savePath, fileName);
                using (var stream = new FileStream(fileUrl, FileMode.Create))
                {
                    await file.CopyToAsync(stream);
                }

                model.ImagePath = fileName;
                model.UserId = (int)HttpContext.Session.GetInt32("id");
                await _context.AddAsync(model);
                await _context.SaveChangesAsync();
                return Json(true);
            }
            return Json(false);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
