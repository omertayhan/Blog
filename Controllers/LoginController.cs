using Blog.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Blog.Controllers
{
    public class LoginController : Controller
    {
        private readonly ILogger<LoginController> _logger;
        private readonly BlogContext _context;

        public LoginController(ILogger<LoginController> logger, BlogContext context)
        {
            _logger = logger;
            _context = context;
        }

        #region Login and Sign in
        [AllowAnonymous]
        public IActionResult Login()
        {
            return View();
        }
        [AllowAnonymous]
        public IActionResult SignIn()
        {
            return View();
        }
        [AllowAnonymous]
        public IActionResult LoginControl(string email, string password)
        {
            var user = _context.Users.FirstOrDefault(x => x.Email == email && x.Password == password);
            if (user != null)
            {
                HttpContext.Session.SetInt32("id", user.Id);
                HttpContext.Session.SetInt32("admin", user.IsAdmin);
                return RedirectToAction("Index", "Home");
            }
            else
            {
                return RedirectToAction("Login", "Login");
            }

        }

        [AllowAnonymous]
        public async Task<IActionResult> SignInAdd(Users users)
        {
            users.IsAdmin = 0; //this gonna be change
            if (users.Id == 0)
            {
                await _context.AddAsync(users);
            }
            else
            {
                _context.Update(users);
            }
            await _context.SaveChangesAsync();
            //gonna come success msg
            return RedirectToAction("Index", "Home");

        }
        [AllowAnonymous]
        public IActionResult UserExit()
        {
            HttpContext.Session.Remove("admin");
            HttpContext.Session.Remove("id");
            return RedirectToAction("Index", "Home");
        }
        #endregion
    }
}
