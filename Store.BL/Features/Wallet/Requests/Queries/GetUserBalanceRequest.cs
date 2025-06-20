﻿using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store.BL.Features.Wallet.Requests.Queries
{
    public class GetUserBalanceRequest : IRequest<decimal>
    {
        public string UserId { get; set; }
    }
}
