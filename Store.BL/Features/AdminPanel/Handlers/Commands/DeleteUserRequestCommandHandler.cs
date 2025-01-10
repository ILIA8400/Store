using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Store.BL.Features.AdminPanel.Requests.Commands;
using Store.DAL.Identity;
using Store.Repositories.Address;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store.BL.Features.AdminPanel.Handlers.Commands
{
    public class DeleteUserRequestCommandHandler : IRequestHandler<DeleteUserRequestCommand>
    {
        private readonly UserManager<ApplicationUser> userManager;
        private readonly IAddressRepository addressRepository;

        public DeleteUserRequestCommandHandler(UserManager<ApplicationUser> userManager,IAddressRepository addressRepository)
        {
            this.userManager = userManager;
            this.addressRepository = addressRepository;
        }
        public async Task Handle(DeleteUserRequestCommand request, CancellationToken cancellationToken)
        {
            var user = await userManager.Users.SingleOrDefaultAsync(x=>x.PhoneNumber == request.PhoneNumber);
            if (user != null)
            {
                user.IsDeleted = true;
            }        
            await userManager.UpdateAsync(user);
        }
    }
}
