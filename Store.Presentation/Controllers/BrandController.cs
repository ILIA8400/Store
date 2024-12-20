using MediatR;
using Microsoft.AspNetCore.Mvc;
using Store.BL.Features.Brand.Request.Queries;

namespace Store.Presentation.Controllers
{
    public class BrandController : Controller
    {
        private readonly IMediator mediator;

        public BrandController(IMediator mediator)
        {
            this.mediator = mediator;
        }

        public async Task<IActionResult> GetBrands()
        {
            var request = new GetBrandsRequest();
            return Json(await mediator.Send(request));
        }

        [HttpGet("Brand/GetBrands/{categoryId:int}")]
        public async Task<IActionResult> GetBrands([FromRoute] int categoryId = 0)
        {
            var request = new GetBrandsByCategoryIdRequest() { CategoryId = categoryId };
            return Json(await mediator.Send(request));
        }
    }
}
