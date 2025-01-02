using MediatR;
using Store.BL.DTOs;
using Store.BL.Features.Address.Requests.Commands;
using Store.BL.Response;
using Store.Domain.Entities;
using Store.Repositories.Address;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store.BL.Features.Address.Handlers.Commands
{
    public class AddAddressCommandHandler : IRequestHandler<AddAddressRequestCommand, AddressPageDto>
    {
        private readonly IAddressRepository addressRepository;

        public AddAddressCommandHandler(IAddressRepository addressRepository)
        {
            this.addressRepository = addressRepository;
        }
        public async Task<AddressPageDto> Handle(AddAddressRequestCommand request, CancellationToken cancellationToken)
        {
            var newAddress = new Store.Domain.Entities.Address()
            {
                City = request.City,
                UserId = request.UserId,
                UserAddress = request.Address,
                PostalCode = request.PostalCode,
            };

            addressRepository.Add(newAddress);
            await addressRepository.SaveChange();

            var addresses = (await addressRepository.GetAllAddressUser(request.UserId)).Select(x => new AddressInfoResponse
            {
                Address = x.UserAddress,
                City = x.City,
                PostalCode = x.PostalCode
            }).ToList();

            return new AddressPageDto()
            {
                AddressInfoResponses = addresses,
                Address = "",
                City = "",
                PostalCode = ""
            };
        }
    }
}
