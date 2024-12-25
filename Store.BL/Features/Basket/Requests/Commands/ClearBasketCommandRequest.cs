using MediatR;
using Store.BL.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store.BL.Features.Basket.Requests.Commands
{
    public class ClearBasketCommandRequest : IRequest
    {
        public ClearBasketDto ClearBasketDto { get; set; }
    }
}
