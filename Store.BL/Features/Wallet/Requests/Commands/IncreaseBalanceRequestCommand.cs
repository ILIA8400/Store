using MediatR;
using Store.BL.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store.BL.Features.Wallet.Requests.Commands
{
    public class IncreaseBalanceRequestCommand : IRequest<IncreaseBalanceResponse>
    {
        public string UserId { get; set; }
        public decimal Amount { get; set; }
    }
}
