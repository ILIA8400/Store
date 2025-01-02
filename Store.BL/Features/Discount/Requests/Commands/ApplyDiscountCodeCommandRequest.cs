using MediatR;
using Store.BL.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store.BL.Features.Discount.Requests.Commands
{
    public class ApplyDiscountCodeCommandRequest : IRequest<CheckBalanceResponse>
    {
        public string UserId { get; set; }
        public CheckBalanceResponse CheckBalanceResponse { get; set; }
    }
}
