using MediatR;
using Store.BL.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store.BL.Features.Wallet.Requests.Queries
{
    public class CheckBalanceRequest : IRequest<CheckBalanceResponse>
    {
    }
}
