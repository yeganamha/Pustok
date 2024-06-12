using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Pustok.DAL;
using Pustok.Models;

namespace Pustok.Areas.Manage.Controllers
{
    [Area("manage")]
    public class AuthorController : Controller
    {
       private readonly PustokDbContext _context;   

        public AuthorController(PustokDbContext context)
        {
            _context = context;
        }

        public IActionResult Index(int page=1)
        {
            var model = _context.Authors
                .Include(x=>x.Books)
                .Skip((page-1)*3)
                .Take(2).ToList();

            return View(model);
        }


        [HttpGet]
        public IActionResult Create() 
        {
            return View();
        }


        [HttpPost]
        public IActionResult Create(Author author)
        {
            if(!ModelState.IsValid)
                return View(author);

            _context.Authors.Add(author);
            _context.SaveChanges();

            return RedirectToAction("Index");

        }
    }
}
