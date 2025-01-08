using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Store.BL.DTOs;
using Store.BL.Features.AdminPanel.Requests.Queries;
using Store.DAL.Identity;
using Store.Repositories.Wallet;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store.BL.Features.AdminPanel.Handlers.Queries
{
    public class GetUsersAndAdminsRequestHandler : IRequestHandler<GetUsersAndAdminsRequest, UsersInfoDto>
    {
        private readonly UserManager<ApplicationUser> userManager;
        private readonly IWalletRepository walletRepository;

        public GetUsersAndAdminsRequestHandler(UserManager<ApplicationUser> userManager,IWalletRepository walletRepository)
        {
            this.userManager = userManager;
            this.walletRepository = walletRepository;
        }
        public async Task<UsersInfoDto> Handle(GetUsersAndAdminsRequest request, CancellationToken cancellationToken)
        {
            var admins = (await userManager.GetUsersInRoleAsync("Admin"))
                .Select(x=>new UserManageDto
                {
                    PhoneNumber = x.PhoneNumber
                }).ToList();

            var normalUsers = await userManager.Users
                .Select(x => new UserManageDto
                {
                    UserId = x.Id,
                    PhoneNumber = x.PhoneNumber,
                }).ToListAsync();

            foreach (var item in normalUsers)
            {
                item.Balance = await walletRepository.GetBalanceByUserId(item.UserId);
            }


            return new UsersInfoDto
            {
                Admins = admins,
                NormalUsers = normalUsers,
                
            };

        }
    }
}
