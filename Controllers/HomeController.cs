using Microsoft.AspNetCore.Mvc;
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
                Sliders = _context.Sliders.ToList()
            };
           
            return View(vm);
        }

       

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}