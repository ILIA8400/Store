using MediatR;
using Microsoft.AspNetCore.Mvc;
using Store.BL.DTOs;
using Store.BL.Features.Address.Requests.Queries;
using System.Security.Claims;

namespace Store.Presentation.Controllers
{
    public class AddressController : Controller
    {
        private readonly IMediator mediator;

        public AddressController(IMediator mediator)
        {
            this.mediator = mediator;
        }
        public async Task<IActionResult> Index()
        {
            var request = new GetAllAddressRequest() { UserId = User.FindFirstValue(ClaimTypes.NameIdentifier) };
            var response = await mediator.Send(request);
            return View(response);
        }

        public async Task<IActionResult> CreateAddress()
        {
            return View("CreateAddress");
        }


        [HttpPost]
        public async Task<IActionResult> CreateAddress(CreateAddressDto createAddressDto)
        {
            return View();
        }
    }
}
