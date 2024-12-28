using MediatR;
using Store.BL.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store.BL.Features.Address.Requests.Queries
{
    public class GetAllAddressRequest : IRequest<List<AddressInfoResponse>>
    {
        public string UserId { get; set; }
    }
}
