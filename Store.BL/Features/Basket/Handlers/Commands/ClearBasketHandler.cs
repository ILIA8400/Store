using MediatR;
using Store.BL.Features.Basket.Requests.Commands;
using Store.Repositories.Basket;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store.BL.Features.Basket.Handlers.Commands
{
    public class ClearBasketHandler : IRequestHandler<ClearBasketCommandRequest>
    {
        private readonly IBasketRepository basketRepository;

        public ClearBasketHandler(IBasketRepository basketRepository)
        {
            this.basketRepository = basketRepository;
        }
        public async Task Handle(ClearBasketCommandRequest request, CancellationToken cancellationToken)
        {
            await basketRepository.ClearBasket(request.ClearBasketDto.UserId);
        }
    }
}
