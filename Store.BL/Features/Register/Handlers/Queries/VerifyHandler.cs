using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Caching.Memory;
using Store.BL.Features.Register.Requests.Queries;
using Store.DAL.Identity;
using Store.Domain.Entities;
using Store.Repositories.Wallet;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store.BL.Features.Register.Handlers.Queries
{
    public class VerifyHandler : IRequestHandler<VerifyRequest>
    {
        private readonly IMemoryCache memoryCache;
        private readonly UserManager<ApplicationUser> userManager;
        private readonly IWalletRepository walletRepository;

        public VerifyHandler(IMemoryCache memoryCache,UserManager<ApplicationUser> userManager,IWalletRepository walletRepository)
        {
            this.memoryCache = memoryCache;
            this.userManager = userManager;
            this.walletRepository = walletRepository;
        }

        public async Task Handle(VerifyRequest request, CancellationToken cancellationToken)
        {
            // PhoneNumber
            if (request.VerifyCodeDto.Code != int.Parse(memoryCache.Get("09104641358").ToString()))
            {
                throw new InvalidOperationException("Invalid Code");
            }
             // PhoneNumber
            var newUser = new ApplicationUser
            {
                PhoneNumber = "09104641358",
                UserName = "09104641358"
            };

            var result = await userManager.CreateAsync(newUser);
            if(!result.Succeeded)
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
                var newWallet = new Wallet()
                {
                    Balance = 0,
                    UserId = newUser.Id
                };

                walletRepository.Add(newWallet);
                await walletRepository.SaveChange();
            }
        }
    }
}
