using MediatR;
using Microsoft.AspNetCore.Mvc;
using Store.BL.Features.AdminPanel.Requests.Queries;

namespace Store.Presentation.Controllers
{
    public class AdminPanelController : Controller
    {
        private readonly IMediator mediator;

        public AdminPanelController(IMediator mediator)
        {
            this.mediator = mediator;
        }

        public async Task<IActionResult> Index()
        {
            var request = new GetInfoAdminPanelRequest();
            return View(await mediator.Send(request));
        }
    }
}
