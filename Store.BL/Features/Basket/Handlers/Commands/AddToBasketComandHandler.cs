using MediatR;
using Microsoft.AspNetCore.Identity;
using Store.BL.Features.Basket.Requests.Commands;
using Store.DAL.Identity;
using Store.Repositories.Basket;
using Store.Repositories.Product;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store.BL.Features.Basket.Handlers.Commands
{
    public class AddToBasketComandHandler : IRequestHandler<AddToBasketRequestCommand>
    {
        private readonly IBasketRepository basketRepository;
        private readonly IProductRepository productRepository;
        private readonly UserManager<ApplicationUser> userManager;

        public AddToBasketComandHandler(IBasketRepository basketRepository,IProductRepository productRepository,UserManager<ApplicationUser> userManager)
        {
            this.basketRepository = basketRepository;
            this.productRepository = productRepository;
            this.userManager = userManager;
        }
        public async Task Handle(AddToBasketRequestCommand request, CancellationToken cancellationToken)
        {
            var user = await userManager.FindByNameAsync(request.BasketItemDto.UserName);
            var productItem = await productRepository.GetById(request.BasketItemDto.ProductId);
            await basketRepository.AddToBasket(productItem, request.BasketItemDto.Quentity, user.Id);
        }
    }
}
