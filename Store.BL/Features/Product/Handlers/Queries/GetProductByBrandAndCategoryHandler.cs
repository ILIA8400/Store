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
    public class GetProductByBrandAndCategoryHandler : IRequestHandler<GetProductByBrandAndCategoryRequest, List<ProductInfoRespose>>
    {
        private readonly IProductRepository productRepository;

        public GetProductByBrandAndCategoryHandler(IProductRepository productRepository)
        {
            this.productRepository = productRepository;
        }
        public async Task<List<ProductInfoRespose>> Handle(GetProductByBrandAndCategoryRequest request, CancellationToken cancellationToken)
        {
            var products = (await productRepository.GetProductByCategoryAndBrand(request.CategoryId, request.BrandId))
                .Select(x=> new ProductInfoRespose
                {
                    ProductId = x.ProductId,
                    ProductName = x.ProductName,
                    Description = x.Description,
                    Price = x.Price,
                    Medias = x.Medias
                }).ToList();
            foreach (var product in products)
            {
                foreach (var media in product.Medias)
                {
                    media.Product = null;
                }
            }
            return products;
        }
    }
}
