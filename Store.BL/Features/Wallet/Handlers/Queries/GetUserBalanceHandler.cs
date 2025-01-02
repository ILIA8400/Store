using MediatR;
using Store.BL.Features.Wallet.Requests.Queries;
using Store.Repositories.Wallet;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store.BL.Features.Wallet.Handlers.Queries
{
    public class GetUserBalanceHandler : IRequestHandler<GetUserBalanceRequest, decimal>
    {
        private readonly IWalletRepository walletRepository;

        public GetUserBalanceHandler(IWalletRepository walletRepository)
        {
            this.walletRepository = walletRepository;
        }
        public async Task<decimal> Handle(GetUserBalanceRequest request, CancellationToken cancellationToken)
        {
            return await walletRepository.GetBalanceByUserId(request.UserId);
        }
    }
}
