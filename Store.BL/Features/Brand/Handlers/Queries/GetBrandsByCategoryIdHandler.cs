using MediatR;
using Store.BL.Features.Brand.Request.Queries;
using Store.BL.Response;
using Store.Repositories.Brand;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store.BL.Features.Brand.Handlers.Queries
{
    public class GetBrandsByCategoryIdHandler : IRequestHandler<GetBrandsByCategoryIdRequest, List<BrandResponse>>
    {
        private readonly IBrandRepository brandRepository;

        public GetBrandsByCategoryIdHandler(IBrandRepository brandRepository)
        {
            this.brandRepository = brandRepository;
        }
        public async Task<List<BrandResponse>> Handle(GetBrandsByCategoryIdRequest request, CancellationToken cancellationToken)
        {
            Console.WriteLine();
            return (await brandRepository.GetBrandsByCategoryId(request.CategoryId)).Select(x=> new BrandResponse
            {
                BrandId = x.BrandId,
                BrandName = x.BrandName
            }).ToList();          
        }
    }
}
