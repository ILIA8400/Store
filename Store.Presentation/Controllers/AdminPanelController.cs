using Microsoft.AspNetCore.Mvc;

namespace Store.Presentation.Controllers
{
    public class AdminPanelController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
