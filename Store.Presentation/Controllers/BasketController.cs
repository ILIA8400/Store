using Microsoft.AspNetCore.Mvc;

namespace Store.Presentation.Controllers
{
    public class BasketController : Controller
    {

        // Display Basket
        public IActionResult Index()
        {
            return View();
        }

        // Add to Basket
        public Task<IActionResult> AddToBasket()
        {
            throw new NotImplementedException();
        }

        // Remove from Basket
        public Task<IActionResult> RemoveFromBasket()
        {
            throw new NotImplementedException();
        }

        // Total Price
        public Task<IActionResult> GetTotalPrice()
        {
            throw new NotImplementedException();
        }

        // Clear Basket
        public Task<IActionResult> ClearBasket()
        {
            throw new NotImplementedException();
        }
    }
}
