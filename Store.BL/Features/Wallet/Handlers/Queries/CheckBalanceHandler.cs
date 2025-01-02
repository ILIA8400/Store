using MediatR;
using Store.BL.Features.Wallet.Requests.Queries;
using Store.BL.Response;
using Store.Repositories.Basket;
using Store.Repositories.Wallet;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store.BL.Features.Wallet.Handlers.Queries
{
    public class CheckBalanceHandler : IRequestHandler<CheckBalanceRequest, CheckBalanceResponse>
    {
        private readonly IWalletRepository walletRepository;
        private readonly IBasketRepository basketRepository;

        public CheckBalanceHandler(IWalletRepository walletRepository,IBasketRepository basketRepository)
        {
            this.walletRepository = walletRepository;
            this.basketRepository = basketRepository;
        }
        public async Task<CheckBalanceResponse> Handle(CheckBalanceRequest request, CancellationToken cancellationToken)
        {
            request.TotalAmount = await basketRepository.GetTotalPrice(request.UserId);
            var userWalletAndDiscount = await walletRepository.GetWalletByUserAndDisount(request.UserId);
            var totalNumberOfProducts = await basketRepository.GetTotalNumberOfProducts(request.UserId);
            if (userWalletAndDiscount == null)
            {
                throw new Exception("کیف پول پیدا نشذ !!!");
            }

            decimal discountAmount = request.TotalAmount;
            byte? discount = 0;

            var response = new CheckBalanceResponse()
            {
                IsBalance = false,
                Balance = userWalletAndDiscount.Balance,
                Discount = discount,
                DiscountedAmount = discountAmount,
                TotalAmount = request.TotalAmount,
                TotalNumberOfProducts = totalNumberOfProducts
            };

            if (userWalletAndDiscount.Balance < request.TotalAmount)
            {                              
                return response;
            }
            else
            {
                
                //if (userWalletAndDiscount.User.Discount != null)
                //{
                //    discountAmount = (userWalletAndDiscount.User.Discount.DiscountPercentage / 100) * request.TotalAmount;
                //    discount = userWalletAndDiscount.User.Discount.DiscountPercentage;
                //}               
                response.IsBalance = true;
                return response;
            }
        }
    }
}
