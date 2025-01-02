using MediatR;
using Microsoft.AspNetCore.Mvc;
using Store.BL.DTOs;
using Store.BL.Features.Address.Requests.Commands;
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
            var dto = new AddressPageDto
            {
                AddressInfoResponses = response
            };
            return View(dto);
        }

        //public async Task<IActionResult> CreateAddress()
        //{
        //    return View("CreateAddress");
        //}


        [HttpPost]
        public async Task<IActionResult> CreateAddress([Bind("City","Address","PostalCode")]AddressPageDto addressPageDto)
        {
            var request = new AddAddressRequestCommand() 
            { 
                UserId = User.FindFirstValue(ClaimTypes.NameIdentifier),
                PostalCode = addressPageDto.PostalCode,
                City = addressPageDto.City,
                Address = addressPageDto.Address
            };

            var response = await mediator.Send(request);
            return View("Index", response);
        }

        [HttpPost]
        public async Task<IActionResult> RegisterDefaultAddress([FromForm]int address = 0)
        {
            var request = new RegisterDefaultAddressRequestCommand
            {
                UserId = User.FindFirstValue(ClaimTypes.NameIdentifier),
                DefaultAddressId = address,
            };
            await mediator.Send(request);
            return RedirectToAction("Index","Payment");
        }
    }
}
