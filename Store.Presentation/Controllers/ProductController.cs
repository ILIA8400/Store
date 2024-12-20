using MediatR;
using Microsoft.AspNetCore.Mvc;
using Store.BL.Features.Brand.Request.Queries;
using Store.BL.Features.Category.Requests.Queries;
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

        public async Task<IActionResult> GetProducts()
        {
            var request = new GetProductsRequest();
            return Json(await mediator.Send(request));
        }


        [HttpGet("Product/GetProductsByBrandAndCategory/{brandId:int}_{categoryId:int}")]
        public async Task<IActionResult> GetProductsByBrandAndCategory([FromRoute] int brandId, [FromRoute] int categoryId = 0)
        {
            var request = new GetProductByBrandAndCategoryRequest() { BrandId = brandId, CategoryId = categoryId };
            return Json(await mediator.Send(request));
        }
    }
}
