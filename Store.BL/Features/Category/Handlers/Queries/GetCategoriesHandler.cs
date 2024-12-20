using MediatR;
using Store.BL.Features.Category.Requests.Queries;
using Store.BL.Response;
using Store.Repositories.Category;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store.BL.Features.Category.Handlers.Queries
{
    public class GetCategoriesHandler : IRequestHandler<GetCategoriesRequest, List<CategoryResponse>>
    {
        private readonly ICategoryRepository categoryRepository;

        public GetCategoriesHandler(ICategoryRepository categoryRepository)
        {
            this.categoryRepository = categoryRepository;
        }

        public async Task<List<CategoryResponse>> Handle(GetCategoriesRequest request, CancellationToken cancellationToken)
        {
            var categories = (await categoryRepository.GetAll()).Select(cat => new CategoryResponse
            {
                CategoryId = cat.CategoryId,
                CategoryName = cat.CategoryName,
                ParentId = cat.ParentId,
                Parent = cat.Parent
            }).ToList();

            return categories;
        }
    }
}
