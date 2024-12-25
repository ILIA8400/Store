using MediatR;
using Store.BL.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace Store.BL.Features.Basket.Requests.Queries
{
    public class GetBasketUserRequest : IRequest<BasketResponse>
    {
        public string UserId { get; set; }
    }
}
