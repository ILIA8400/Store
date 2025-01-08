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
    public class AddAdminRequestCommandHandler : IRequestHandler<AddAdminRequestCommand>
    {
        private readonly UserManager<ApplicationUser> userManager;
        private readonly RoleManager<IdentityRole> roleManager;

        public AddAdminRequestCommandHandler(UserManager<ApplicationUser> userManager,RoleManager<IdentityRole> roleManager)
        {
            this.userManager = userManager;
            this.roleManager = roleManager;
        }
        public async Task Handle(AddAdminRequestCommand request, CancellationToken cancellationToken)
        {
            if (!(await roleManager.RoleExistsAsync("Admin")))
                await roleManager.CreateAsync(new IdentityRole { Name = "Admin" });

            var user = await userManager.Users.FirstOrDefaultAsync(x => x.PhoneNumber == request.UsersInfoDto.PhoneNumber);

            if(!(await userManager.IsInRoleAsync(user,"Admin")))
                await userManager.AddToRoleAsync(user, "Admin");

        }
    }
}
