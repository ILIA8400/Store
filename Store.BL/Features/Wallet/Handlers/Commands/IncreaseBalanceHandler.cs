using MediatR;
using Store.BL.Features.Wallet.Requests.Commands;
using Store.BL.Response;
using Store.Repositories.Wallet;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store.BL.Features.Wallet.Handlers.Commands
{
    public class IncreaseBalanceHandler : IRequestHandler<IncreaseBalanceRequestCommand, IncreaseBalanceResponse>
    {
        private readonly IWalletRepository walletRepository;

        public IncreaseBalanceHandler(IWalletRepository walletRepository)
        {
            this.walletRepository = walletRepository;
        }

        public async Task<IncreaseBalanceResponse> Handle(IncreaseBalanceRequestCommand request, CancellationToken cancellationToken)
        {
            var result = await walletRepository.IncreaseBalance(request.UserId, request.Amount);
            if (result)
            {
                return new IncreaseBalanceResponse
                {
                    Message = "موجودی با موفقیت افزایش یافت"
                };
            }
            else
            {
                return new IncreaseBalanceResponse
                {
                    Message = "افزایش موجودی موفقیت امیز نبود"
                };
            }
        }
    }
}
