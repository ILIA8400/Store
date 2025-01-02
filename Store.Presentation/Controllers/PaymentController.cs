using MediatR;
using Microsoft.AspNetCore.Mvc;
using Store.BL.Features.Discount.Requests.Commands;
using Store.BL.Features.Wallet.Requests.Queries;
using Store.BL.Response;
using System.Security.Claims;

namespace Store.Presentation.Controllers
{
    public class PaymentController : Controller
    {
        private readonly IMediator mediator;

        public PaymentController(IMediator mediator)
        {
            this.mediator = mediator;
        }

        public async Task<IActionResult> Index()
        {
            var request = new CheckBalanceRequest() { UserId = User.FindFirstValue(ClaimTypes.NameIdentifier) };
            var result = await mediator.Send(request);

            return View(result);
        }

        
        // اعمال کد تخفیف
        [HttpPost]
        public async Task<IActionResult> ApplyDiscountCode(CheckBalanceResponse checkBalance)
        {
            var request = new ApplyDiscountCodeCommandRequest() 
            { 
                UserId = User.FindFirstValue(ClaimTypes.NameIdentifier), 
                CheckBalanceResponse = checkBalance
            };

            var result = await mediator.Send(request);

            return View("Index",result);
        }
    }
}
