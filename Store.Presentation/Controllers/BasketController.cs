using Microsoft.AspNetCore.Mvc;

namespace Store.Presentation.Controllers
{
    public class BasketController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
