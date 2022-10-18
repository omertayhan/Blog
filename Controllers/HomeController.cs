﻿using Blog.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

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

        #region CRUD Category
        public IActionResult Category()
        {
            List<Category> list = _context.Category.ToList();
            return View(list);
        }
        public async Task<IActionResult> AddCategory(Category category)
        {
            if (category.Id == 0)
            {
                await _context.AddAsync(category);
            }
            else
            {
                _context.Update(category);
            }
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Category));
        }
        public async Task<ActionResult> DeleteCategory(int? id)
        {
            Category category = await _context.Category.FindAsync(id);
            _context.Remove(category);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Category));
        }
        public async Task<ActionResult> CategoryDetails(int id)
        {
            var category = await _context.Category.FindAsync(id);
            return Json(category); // category transform to json
        }
        #endregion

        #region CRUD Users
        public IActionResult Users()
        {
            List<Users> list = _context.Users.ToList();
            return View(list);
        }
        public async Task<IActionResult> AddUser(Users users)
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
            return RedirectToAction(nameof(Users));
        }
        public async Task<ActionResult> DeleteUser(int? id)
        {
            Users users = await _context.Users.FindAsync(id);
            _context.Remove(users);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Users));
        }
        public async Task<ActionResult> UserDetails(int id)
        {
            var user = await _context.Users.FindAsync(id);
            return Json(user); // category transform to json
        }
        #endregion
        public IActionResult About()
        {
            return View();
        }
        public IActionResult Login()
        {
            return View();
        }
        public IActionResult SignIn()
        {
            return View();
        }
        public IActionResult Contact()
        {
            return View();
        }
        public IActionResult Index()
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