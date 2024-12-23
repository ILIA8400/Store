using MediatR;
using Microsoft.AspNetCore.Identity;
using Store.BL.Features.Register.Requests.Queries;
using Store.DAL.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store.BL.Features.Register.Handlers.Queries
{
    public class LogoutHandler : IRequestHandler<LogoutRequest>
    {
        private readonly SignInManager<ApplicationUser> signInManager;

        public LogoutHandler(SignInManager<ApplicationUser> signInManager)
        {
            this.signInManager = signInManager;
        }
        public async Task Handle(LogoutRequest request, CancellationToken cancellationToken)
        {
            await signInManager.SignOutAsync();
        }
    }
}
