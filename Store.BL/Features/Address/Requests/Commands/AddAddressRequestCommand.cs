using MediatR;
using Store.BL.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store.BL.Features.Address.Requests.Commands
{
    public class AddAddressRequestCommand : IRequest<AddressPageDto>
    {
        public string UserId { get; set; }
        public string City { get; set; }
        public string Address { get; set; }
        public string PostalCode { get; set; }
    }
}
