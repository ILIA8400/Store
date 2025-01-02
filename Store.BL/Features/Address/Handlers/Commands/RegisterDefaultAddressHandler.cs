using MediatR;
using Microsoft.AspNetCore.Identity;
using Store.BL.Features.Address.Requests.Commands;
using Store.DAL.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store.BL.Features.Address.Handlers.Commands
{
    public class RegisterDefaultAddressHandler : IRequestHandler<RegisterDefaultAddressRequestCommand>
    {
        private readonly UserManager<ApplicationUser> userManager;

        public RegisterDefaultAddressHandler(UserManager<ApplicationUser> userManager)
        {
            this.userManager = userManager;
        }
        public async Task Handle(RegisterDefaultAddressRequestCommand request, CancellationToken cancellationToken)
        {
            var user = await userManager.FindByIdAsync(request.UserId);
            user.DefaultAddressId = request.DefaultAddressId;
            await userManager.UpdateAsync(user);
        }
    }
}
