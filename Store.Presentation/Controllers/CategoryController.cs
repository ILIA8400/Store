using MediatR;
using Microsoft.AspNetCore.Mvc;
using Store.BL.Features.Category.Requests.Queries;

namespace Store.Presentation.Controllers
{
    public class CategoryController : Controller
    {
        private readonly IMediator mediator;

        public CategoryController(IMediator mediator)
        {
            this.mediator = mediator;
        }

        public async Task<IActionResult> GetCategories()
        {
            var request = new GetCategoriesRequest();
            var response = await mediator.Send(request);
            return Json(response);
        }
    }
}
