using MediatR;
using Microsoft.AspNetCore.Mvc;
using Store.BL.Features.Wallet.Requests.Commands;
using Store.BL.Features.Wallet.Requests.Queries;
using Store.BL.Response;
using System.Security.Claims;

namespace Store.Presentation.Controllers
{
    //[Authorize(Roles ="User")]
    public class WalletController : Controller
    {
        private readonly IMediator mediator;

        public WalletController(IMediator mediator)
        {
            this.mediator = mediator;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult ContinueShopping()
        {
            return View();
        }

        public async Task<IActionResult> SuccessfulPurchase([Bind("DiscountedAmount", "Discount")]CheckBalanceResponse checkBalanceResponse)
        {
            var request = new DecreasingBalanceCommandRequest()
            {
                Amount = checkBalanceResponse.DiscountedAmount,
                UserId = User.FindFirstValue(ClaimTypes.NameIdentifier),
                Discount = checkBalanceResponse.Discount ?? 0,
            };
            await mediator.Send(request);
            return RedirectToAction("Index","Home"); 
        }

        // افزایش موجودی کاربر
        [HttpPost]
        public async Task<IActionResult> IncreaseBalance([FromForm]decimal amount = 0)
        {
            var request = new IncreaseBalanceRequestCommand()
            {
                UserId = User.FindFirstValue(ClaimTypes.NameIdentifier),
                Amount = amount
            };
            await mediator.Send(request);
            return RedirectToAction("Index","Home"); 
        }

        // افزایش موجودی و برگشت به ادامه فرایند خرید
        [HttpPost]
        public async Task<IActionResult> IncreaseBalanceAndContinue([FromForm] decimal amount = 0)
        {
            var request = new IncreaseBalanceRequestCommand()
            {
                UserId = User.FindFirstValue(ClaimTypes.NameIdentifier),
                Amount = amount
            };
            await mediator.Send(request);
            return RedirectToAction("Index", "Payment");
        }


        // گرفتن موجودی کاربر
        public async Task<decimal> GetUserBalance()
        {
            if (User.Identity.IsAuthenticated)
            {
                var request = new GetUserBalanceRequest() { UserId = User.FindFirstValue(ClaimTypes.NameIdentifier) };
                return await mediator.Send(request);
            }
            return 0;
        }
    }
}
