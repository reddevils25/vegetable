﻿using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using Vegetable.Models;
using Vegetable.Utilities;

namespace Vegetable.Controllers
{
    public class HomeController : Controller
    {
        private readonly VegetablesContext _context;
        private readonly ILogger<HomeController> _logger;
        public HomeController(VegetablesContext context, ILogger<HomeController> logger)
        {
            _context = context;
            _logger = logger;
        }
        public IActionResult Index()
        {
            ViewBag.Category = _context.Categories.ToList();
            ViewBag.productNew = _context.Products.Where(m => m.IsActive == true).ToList();

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
        [HttpPost]
        public IActionResult Logout()
        {
            // Gọi phương thức Logout trong lớp Function để xóa thông tin người dùng
            Function.Logout();

            // Redirect về trang chủ hoặc trang đăng nhập
            return RedirectToAction("Index", "Home");
        }
    }
}
