using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Store.BL.Features.AdminPanel.Requests.Commands;
using Store.DAL.Identity;
using Store.Repositories.Wallet;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store.BL.Features.AdminPanel.Handlers.Commands
{
    public class UpdateUserRequestCommandHandler : IRequestHandler<UpdateUserRequestCommand>
    {
        private readonly UserManager<ApplicationUser> userManager;
        private readonly IWalletRepository walletRepository;

        public UpdateUserRequestCommandHandler(UserManager<ApplicationUser> userManager,IWalletRepository walletRepository)
        {
            this.userManager = userManager;
            this.walletRepository = walletRepository;
        }
        public async Task Handle(UpdateUserRequestCommand request, CancellationToken cancellationToken)
        {
            await walletRepository.UpdateBalanceWithPhoneNumber(request.OldPhoneNumber,(decimal)request.UsersInfoDto.Balance);

            var user = await userManager.Users.SingleOrDefaultAsync(x=>x.PhoneNumber == request.OldPhoneNumber);
            user.PhoneNumber = request.UsersInfoDto.PhoneNumber;
            await userManager.UpdateAsync(user);
        }
    }
}
