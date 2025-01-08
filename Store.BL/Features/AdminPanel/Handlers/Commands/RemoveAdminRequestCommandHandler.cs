using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Store.BL.Features.AdminPanel.Requests.Commands;
using Store.DAL.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store.BL.Features.AdminPanel.Handlers.Commands
{
    public class RemoveAdminRequestCommandHandler : IRequestHandler<RemoveAdminRequestCommand>
    {
        private readonly UserManager<ApplicationUser> userManager;
        private readonly RoleManager<IdentityRole> roleManager;

        public RemoveAdminRequestCommandHandler(UserManager<ApplicationUser> userManager, RoleManager<IdentityRole> roleManager)
        {
            this.userManager = userManager;
            this.roleManager = roleManager;
        }
        public async Task Handle(RemoveAdminRequestCommand request, CancellationToken cancellationToken)
        {
            var user = await userManager.Users.FirstOrDefaultAsync(x => x.PhoneNumber == request.UsersInfoDto.PhoneNumber);

            if ((await userManager.IsInRoleAsync(user, "Admin")))
                await userManager.RemoveFromRoleAsync(user, "Admin");
        }
    }
}
