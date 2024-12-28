using Store.Domain.Entities;
using Store.Repositories.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AddressEntity = Store.Domain.Entities.Address;

namespace Store.Repositories.Address
{
    public interface IAddressRepository : IGenericRepository<AddressEntity>
    {
        Task<List<AddressEntity>> GetAllAddressUser(string userId);
    }
}
