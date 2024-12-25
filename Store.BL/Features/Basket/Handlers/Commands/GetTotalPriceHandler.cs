using MediatR;
using Store.BL.Features.Basket.Requests.Queries;
using Store.Repositories.Basket;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store.BL.Features.Basket.Handlers.Commands
{
    public class GetTotalPriceHandler : IRequestHandler<GetTotalPriceRequest, decimal>
    {
        private readonly IBasketRepository basketRepository;

        public GetTotalPriceHandler(IBasketRepository basketRepository)
        {
            this.basketRepository = basketRepository;
        }
        public async Task<decimal> Handle(GetTotalPriceRequest request, CancellationToken cancellationToken)
        {
            return await basketRepository.GetTotalPrice(request.UserId);
        }
    }
}
