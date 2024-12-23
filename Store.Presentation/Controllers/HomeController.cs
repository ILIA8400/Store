using System.Diagnostics;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Store.Presentation.Models;

namespace Store.Presentation.Controllers
{
    public class HomeController : Controller
    {
        //private readonly IMediator _mediator;

        //public HomeController(IMediator mediator)
        //{
        //    this._mediator = mediator;
        //}

        public IActionResult Index()
        {
            return View();
        }


        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
