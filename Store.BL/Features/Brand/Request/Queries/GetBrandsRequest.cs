using MediatR;
using Store.BL.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store.BL.Features.Brand.Request.Queries
{
    public class GetBrandsRequest : IRequest<List<BrandResponse>>
    {
    }
}
