using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store.BL.Features.Address.Requests.Commands
{
    public class RegisterDefaultAddressRequestCommand : IRequest
    {
        public string UserId { get; set; }
        public int DefaultAddressId { get; set; }
    }
}
