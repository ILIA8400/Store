using MediatR;
using Microsoft.AspNetCore.Mvc;
using Store.BL.Features.Wallet.Requests.Queries;

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
            var request = new CheckBalanceRequest();
            await mediator.Send(request);
            return View();
        }


    }
}
