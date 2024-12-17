using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Store.Presentation.Controllers
{
    public class ProductController : Controller
    {
        private readonly IMediator mediator;

        public ProductController(IMediator mediator)
        {
            this.mediator = mediator;
        }

        public Task<IActionResult> GetCategories()
        {

        }

        public Task<IActionResult> GetBrands(string Category)
        {

        }

        public Task<IActionResult> GetProducts()
        {

        }
    }
}
