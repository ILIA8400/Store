using MediatR;
using Store.BL.Features.Address.Requests.Queries;
using Store.BL.Response;
using Store.Repositories.Address;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store.BL.Features.Address.Handlers.Queries
{
    public class GetAllAddressHandler : IRequestHandler<GetAllAddressRequest, List<AddressInfoResponse>>
    {
        private readonly IAddressRepository addressRepository;

        public GetAllAddressHandler(IAddressRepository addressRepository)
        {
            this.addressRepository = addressRepository;
        }
        public async Task<List<AddressInfoResponse>> Handle(GetAllAddressRequest request, CancellationToken cancellationToken)
        {
            return (await addressRepository.GetAllAddressUser(request.UserId)).Select(x=> new AddressInfoResponse
            {
                Address = x.UserAddress,
                City = x.City,
                PostalCode = x.PostalCode
            }).ToList();
        }
    }
}
