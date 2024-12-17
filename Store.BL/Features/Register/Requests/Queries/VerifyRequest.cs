using MediatR;
using Store.BL.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store.BL.Features.Register.Requests.Queries
{
    public class VerifyRequest : IRequest
    {
        public VerifyCodeDto VerifyCodeDto { get; set; }
    }
}
