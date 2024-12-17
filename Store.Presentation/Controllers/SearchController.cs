using Microsoft.AspNetCore.Mvc;

namespace Store.Presentation.Controllers
{
    public class SearchController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
