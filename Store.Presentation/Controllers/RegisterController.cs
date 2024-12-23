using MediatR;
using Microsoft.AspNetCore.Mvc;
using Store.BL.DTOs;
using Store.BL.Features.Register.Requests.Queries;

namespace Store.Presentation.Controllers
{
    public class RegisterController : Controller
    {
        private readonly IMediator mediator;

        public RegisterController(IMediator mediator)
        {
            this.mediator = mediator;
        }

        public IActionResult Index()
        {
            return View();
        }
        public async Task<IActionResult> Login()
        {
            return View("VerifyCode");
        }

        [HttpPost]
        public async Task<IActionResult> Login(VerifyCodeDto verifyCodeDto)
        {
            try
            {
                var request = new VerifyRequest() { VerifyCodeDto = verifyCodeDto };
                await mediator.Send(request);
                return RedirectToAction("Index", "Home");
            }
            catch (Exception ex)
            {
                // نمیتونه خطارو بگیره
                return BadRequest("خطا داریم");
            }
        }

        [HttpPost]
        public async Task<IActionResult> SendVerifyCode(PhoneNumberDto numberDto)
        {
            try
            {
                var request = new VerifyCodeRequest() { PhoneNumberDto = numberDto };
                var response = await mediator.Send(request);

                return RedirectToAction("Login");
            }
            catch (Exception ex)
            {
                return Json(new
                {
                    success = false,
                    codeSent = false,
                    message = ex.Message
                });
            }
        }

        public async Task<IActionResult> Logout()
        {
            var request = new LogoutRequest();
            await mediator.Send(request);
            return RedirectToAction("Index", "Home");
        }
    }
}
