using Microsoft.AspNetCore.Mvc;
using Store.BL.DTOs;
//using Store.BL.Features.Basket.Requests.Commands;

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
        public Task<IActionResult> AddToBasket(BasketItemDto basketItemDto)
        {
            basketItemDto.UserName = User.Identity.Name;
            //var request = new AddToBasketRequestCommand()
            //{
            //    BasketItemDto = basketItemDto
            //};
            return null;
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
