using MediatR;
using Store.BL.Features.Basket.Requests.Commands;
using Store.Repositories.Basket;
using Store.Repositories.Product;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store.BL.Features.Basket.Handlers.Commands
{
    public class RemoveFromBasketHandler : IRequestHandler<RemoveFromBasketRequestCommand>
    {
        private readonly IBasketRepository basketRepository;
        private readonly IProductRepository productRepository;

        public RemoveFromBasketHandler(IBasketRepository basketRepository,IProductRepository productRepository)
        {
            this.basketRepository = basketRepository;
            this.productRepository = productRepository;
        }
        public async Task Handle(RemoveFromBasketRequestCommand request, CancellationToken cancellationToken)
        {
            var product = await productRepository.GetById(request.RemoveFromBasketDto.ProductId);
            await basketRepository.RemoveFromBasket(product,request.RemoveFromBasketDto.UserId);
        }
    }
}
