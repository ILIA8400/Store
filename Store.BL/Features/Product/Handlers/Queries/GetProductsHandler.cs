using MediatR;
using Store.BL.Features.Product.Requests.Queries;
using Store.BL.Response;
using Store.Repositories.Product;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store.BL.Features.Product.Handlers.Queries
{
    public class GetProductsHandler : IRequestHandler<GetProductsRequest, List<ProductInfoRespose>>
    {
        private readonly IProductRepository productRepository;

        public GetProductsHandler(IProductRepository productRepository)
        {
            this.productRepository = productRepository;
        }

        public async Task<List<ProductInfoRespose>> Handle(GetProductsRequest request, CancellationToken cancellationToken)
        {
            var products = (await productRepository.GetAll()).Select(p => new ProductInfoRespose
            {
                 ProductName = p.ProductName,
                 Price = p.Price,
                 Description = p.Description,
            }).ToList();

            return products;
        }
    }
}
