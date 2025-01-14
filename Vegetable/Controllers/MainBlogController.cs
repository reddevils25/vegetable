﻿using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Vegetable.Models;

namespace Vegetable.Controllers
{
    public class MainBlogController : Controller
    {

        private readonly VegetablesContext _context;
        public MainBlogController(VegetablesContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            ViewBag.Blogs = _context.Blogs.ToList();
            ViewBag.Categorie = _context.Categories.ToList();
            return View();
        }
    }
}
