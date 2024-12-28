using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Caching.Memory;
using Store.BL.Features.Register.Requests.Queries;
using Store.DAL.Identity;
using Store.Domain.Entities;
using Store.Repositories.Basket;
using Store.Repositories.Wallet;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BasketEntity = Store.Domain.Entities.Basket;
using WalletEntity = Store.Domain.Entities.Wallet;

namespace Store.BL.Features.Register.Handlers.Queries
{
    public class VerifyHandler : IRequestHandler<VerifyRequest>
    {
        private readonly IMemoryCache memoryCache;
        private readonly UserManager<ApplicationUser> userManager;
        private readonly SignInManager<ApplicationUser> signInManager;
        private readonly IWalletRepository walletRepository;
        private readonly IBasketRepository basketRepository;

        public VerifyHandler(
            IMemoryCache memoryCache,UserManager<ApplicationUser> userManager,SignInManager<ApplicationUser> signInManager,
            IWalletRepository walletRepository,
            IBasketRepository basketRepository)
        { 
            this.memoryCache = memoryCache;
            this.userManager = userManager;
            this.signInManager = signInManager;
            this.walletRepository = walletRepository;
            this.basketRepository = basketRepository;
        }

        public async Task Handle(VerifyRequest request, CancellationToken cancellationToken)
        {
            // PhoneNumber
            if (request.VerifyCodeDto.Code != int.Parse(memoryCache.Get("09104641358").ToString()))
            {
                throw new InvalidOperationException("Invalid Code");
            }


            var user = await userManager.FindByNameAsync("09104641358");

            if (user == null)
            {
                // PhoneNumber
                var newUser = new ApplicationUser
                {
                    PhoneNumber = "09104641358",
                    UserName = "09104641358"
                };

                var result = await userManager.CreateAsync(newUser);
                if (!result.Succeeded)
                {
                    StringBuilder stringBuilder = new StringBuilder();
                    foreach (var item in result.Errors)
                    {
                        stringBuilder.AppendLine(item.Description);
                    }
                    throw new Exception(stringBuilder.ToString());
                }
                else
                {
                    newUser.PhoneNumberConfirmed = true;
                    var newWallet = new WalletEntity()
                    {
                        Balance = 0,
                        UserId = newUser.Id
                    };

                    var newBasket = new BasketEntity
                    {
                        TotalAmount = 0,
                        UserId = newUser.Id
                    };

                    walletRepository.Add(newWallet);
                    basketRepository.Add(newBasket);
                    await walletRepository.SaveChange();
                }
            }
            else
            {
                await signInManager.SignInAsync(user,true);
            }
            
             
        }
    }
}
