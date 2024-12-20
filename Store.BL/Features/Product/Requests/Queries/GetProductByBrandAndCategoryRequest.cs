using MediatR;
using Store.BL.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store.BL.Features.Product.Requests.Queries
{
    public class GetProductByBrandAndCategoryRequest : IRequest<List<ProductInfoRespose>>
    {
        public int CategoryId { get; set; }
        public int BrandId { get; set; }
    }
}
