using MediatR;
using Microsoft.AspNetCore.Mvc;
using Store.BL.DTOs;
using Store.BL.Features.Basket.Requests.Commands;
using Store.BL.Features.Basket.Requests.Queries;
using System.Security.Claims;
//using Store.BL.Features.Basket.Requests.Commands;

namespace Store.Presentation.Controllers
{
    public class BasketController : Controller
    {
        private readonly IMediator mediator;

        public BasketController(IMediator mediator)
        {
            this.mediator = mediator;
        }

        // Display Basket
        public async Task<IActionResult> Index()
        {
            var request = new GetBasketUserRequest()
            {
                UserId = User.FindFirstValue(ClaimTypes.NameIdentifier),
            };
            var response = await mediator.Send(request);
            return View(response);
        }

        // Add to Basket
        public async Task<IActionResult> AddToBasket(BasketItemDto basketItemDto)
        {
            basketItemDto.UserName = User.Identity.Name;
            var request = new AddToBasketRequestCommand()
            {
                BasketItemDto = basketItemDto
            };
            await mediator.Send(request);
            return RedirectToAction("Index", "Home");
        }

        // Remove from Basket
        public async Task<IActionResult> RemoveFromBasket(RemoveFromBasketDto removeFromBasketDto)
        {
            removeFromBasketDto.UserId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            var request = new RemoveFromBasketRequestCommand()
            {              
                RemoveFromBasketDto = removeFromBasketDto
            };
            await mediator.Send(request);
            return RedirectToAction("Index");
        }

        // Clear Basket
        [HttpPost]
        public async Task<IActionResult> ClearBasket(ClearBasketDto clearBasketDto)
        {
            clearBasketDto.UserId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            var request = new ClearBasketCommandRequest
            {
                ClearBasketDto = clearBasketDto
            };
            await mediator.Send(request);

            return RedirectToAction("Index");
        }

        // Get Total Price
        public async Task<decimal> GetTotalPrice()
        {
            var request = new GetTotalPriceRequest
            {
                UserId = User.FindFirstValue(ClaimTypes.NameIdentifier)
            };
            return await mediator.Send(request);
        }
       
    }
}
