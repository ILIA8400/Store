using MediatR;
using Microsoft.AspNetCore.Identity;
using Store.BL.Features.Address.Requests.Queries;
using Store.BL.Response;
using Store.DAL.Identity;
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
        private readonly UserManager<ApplicationUser> userManager;

        public GetAllAddressHandler(IAddressRepository addressRepository,UserManager<ApplicationUser> userManager)
        {
            this.addressRepository = addressRepository;
            this.userManager = userManager;
        }
        public async Task<List<AddressInfoResponse>> Handle(GetAllAddressRequest request, CancellationToken cancellationToken)
        {
            var defaultAddressId = (await userManager.FindByIdAsync(request.UserId)).DefaultAddressId;

            var addresses = (await addressRepository.GetAllAddressUser(request.UserId)).Select(x => new AddressInfoResponse
            {
                Id = x.AddressId,
                Address = x.UserAddress,
                City = x.City,
                PostalCode = x.PostalCode,
                IsDefaultAddress = false
            }).ToList();

            foreach (var item in addresses)
            {
                if(item.Id == defaultAddressId)
                {
                    item.IsDefaultAddress = true;
                }
            }
            return addresses;
        }
    }
}
