using MediatR;
using Store.BL.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store.BL.Features.Transaction.Requests.Queries
{
    public class GetAllTransactionsOfUserRequest : IRequest<TransactionsOfUserDto>
    {
        public string PhoneNumber { get; set; }
    }
}
