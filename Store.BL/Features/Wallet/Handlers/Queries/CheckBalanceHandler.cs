using MediatR;
using Store.BL.Features.Wallet.Requests.Queries;
using Store.BL.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store.BL.Features.Wallet.Handlers.Queries
{
    public class CheckBalanceHandler : IRequestHandler<CheckBalanceRequest, CheckBalanceResponse>
    {
        public CheckBalanceHandler()
        {
            
        }
        public Task<CheckBalanceResponse> Handle(CheckBalanceRequest request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
