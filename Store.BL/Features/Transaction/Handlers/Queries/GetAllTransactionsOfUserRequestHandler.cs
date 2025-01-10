using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Store.BL.DTOs;
using Store.BL.Features.Transaction.Requests.Queries;
using Store.DAL.Identity;
using Store.Repositories.Transaction;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store.BL.Features.Transaction.Handlers.Queries
{
    public class GetAllTransactionsOfUserRequestHandler : IRequestHandler<GetAllTransactionsOfUserRequest, TransactionsOfUserDto>
    {
        private readonly ITransactionRepository transactionRepository;
        private readonly UserManager<ApplicationUser> userManager;

        public GetAllTransactionsOfUserRequestHandler(ITransactionRepository transactionRepository,UserManager<ApplicationUser> userManager)
        {
            this.transactionRepository = transactionRepository;
            this.userManager = userManager;
        }
        public async Task<TransactionsOfUserDto> Handle(GetAllTransactionsOfUserRequest request, CancellationToken cancellationToken)
        {
            var userId = (await userManager.Users.SingleOrDefaultAsync(x=>x.PhoneNumber == request.PhoneNumber)).Id;
            return new TransactionsOfUserDto
            {
                TransactionsOfUser = await transactionRepository.GetAllTransactionsOfUser(userId),
                PhoneNumber = request.PhoneNumber,
            };
        }
    }
}
