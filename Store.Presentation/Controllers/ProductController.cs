using MediatR;
using Microsoft.AspNetCore.Mvc;
using Store.BL.Features.Product.Requests.Queries;

namespace Store.Presentation.Controllers
{
    public class ProductController : Controller
    {
        private readonly IMediator mediator;

        public ProductController(IMediator mediator)
        {
            this.mediator = mediator;
        }

        //public Task<IActionResult> GetCategories()
        //{

        //}

        //public Task<IActionResult> GetBrands(string Category)
        //{

        //}

        public async Task<IActionResult> GetProducts()
        {
            var request = new GetProductsRequest();
            return Json(await mediator.Send(request));
        }
    }
}
