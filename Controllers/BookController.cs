using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Pustok.ViewModels;

namespace Pustok.Controllers
{
    public class BookController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult AddToBasket(int id)
        {
            List<BasketItemViewModel> ids;
            var basket = HttpContext.Request.Cookies["basket"];
            if (basket == null) 
            {
                ids = new List<BasketItemViewModel>();
                 ids.Add(new BasketItemViewModel { Count=1, BookId=id});   
            }
            else 
            {
                ids = JsonConvert.DeserializeObject<List<BasketItemViewModel>>(basket);
                var wantedBook = ids.FirstOrDefault(x=> x.BookId==id);

                if (wantedBook != null) 
                {
                    ids.Add(new BasketItemViewModel { Count = 1, BookId = id });
                }

                else
                {
                    wantedBook.Count++;
                }
                
            }
            


            
            HttpContext.Response.Cookies.Append("basket",JsonConvert.SerializeObject(ids));
            return RedirectToAction("index", "home");
        }

        public IActionResult ShowBasket()
        {
        
            var basket = HttpContext.Request.Cookies["basket"];
            return Json(basket);
        }
    }
}
