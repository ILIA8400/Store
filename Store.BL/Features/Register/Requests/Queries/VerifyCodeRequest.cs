using MediatR;
using Store.BL.DTOs;
using Store.BL.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store.BL.Features.Register.Requests.Queries
{
    public class VerifyCodeRequest : IRequest<VerifyCodeResponse>
    {
        public PhoneNumberDto PhoneNumberDto { get; set; }
    }
}
