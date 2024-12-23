using MediatR;
using Store.BL.DTOs;
using Store.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store.BL.Features.Basket.Requests.Commands
{
    public class AddToBasketRequestCommand : IRequest
    {
        public BasketItemDto BasketItemDto { get; set; }
    }
}
