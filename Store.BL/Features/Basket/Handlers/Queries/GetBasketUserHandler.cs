using MediatR;
using Store.BL.Features.Basket.Requests.Queries;
using Store.BL.Response;
using Store.Repositories.Basket;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store.BL.Features.Basket.Handlers.Queries
{
    public class GetBasketUserHandler : IRequestHandler<GetBasketUserRequest, BasketResponse>
    {
        private readonly IBasketRepository basketRepository;

        public GetBasketUserHandler(IBasketRepository basketRepository)
        {
            this.basketRepository = basketRepository;
        }
        public async Task<BasketResponse> Handle(GetBasketUserRequest request, CancellationToken cancellationToken)
        {
            var basketUser = await basketRepository.GetBasketsWithProducts(request.UserId);
            if (basketUser != null)
            {
                return new BasketResponse
                {
                    Basket = basketUser,
                };
            }
            else
            {
                throw new Exception("No Athorize");
            }
        }
    }
}
