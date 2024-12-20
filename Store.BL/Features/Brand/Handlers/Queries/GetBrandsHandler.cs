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
    public class GetBrandsHandler : IRequestHandler<GetBrandsRequest, List<BrandResponse>>
    {
        private readonly IBrandRepository brandRepository;

        public GetBrandsHandler(IBrandRepository brandRepository)
        {
            this.brandRepository = brandRepository;
        }
        public async Task<List<BrandResponse>> Handle(GetBrandsRequest request, CancellationToken cancellationToken)
        {
            return (await brandRepository.GetAll()).Select(x=>new BrandResponse
            {
                BrandId = x.BrandId,
                BrandName = x.BrandName,
            }).ToList();
        }
    }
}
