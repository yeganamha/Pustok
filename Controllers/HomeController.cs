﻿using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Pustok.DAL;
using Pustok.Models;
using Pustok.ViewModels;
using System.Diagnostics;

namespace Pustok.Controllers
{
    public class HomeController : Controller
    {
        private readonly PustokDbContext _context;
        public HomeController(PustokDbContext context)
        {
            _context = context;
            
        }
        public IActionResult Index()
        {
            HomeViewModel vm = new HomeViewModel
            {
                Sliders = _context.Sliders.ToList(),
                BestSellerBooks = _context.Books.Include(x=> x.Author).Include(x=> x.BookImages).Where(x=> x.IsBestSeller).Take(25).ToList(),
                NewBooks = _context.Books.Include(x=> x.Author).Include(x=> x.BookImages).Where(x=> x.IsNew).Take(25).ToList(),
                DisCountedBooks = _context.Books.Include(x=> x.Author).Include(x=> x.BookImages).Where(x=> x.DiscountPercent>0).Take(25).ToList()
            };
           
            return View(vm);
        }

        public IActionResult Contact()
        {
            return View();
        }

       
        public IActionResult SetSession(string key, string value)
        {
            HttpContext.Session.SetString(key, value);
            return Content("");
        }

        public IActionResult GetSession(string key) 
        {
            var value = HttpContext.Session.GetString(key);
            return Content(value);
        }

        public IActionResult SetCookie(string key, string value)
        {
            HttpContext.Response.Cookies.Append(key, value);
            return Content("");
        }

        public IActionResult GetCookie(string key) 
        {
            var value = HttpContext.Request.Cookies[key];
            return Content(value);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}