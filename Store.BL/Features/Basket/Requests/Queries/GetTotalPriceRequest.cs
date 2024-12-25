using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store.BL.Features.Basket.Requests.Queries
{
    public class GetTotalPriceRequest : IRequest<decimal>
    {
        public string UserId { get; set; }
    }
}
