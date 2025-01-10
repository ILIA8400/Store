using DiscountEntity = Store.Domain.Entities.Discount;
using Store.Repositories.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store.Repositories.Discount
{
    public interface IDiscountRepository : IGenericRepository<DiscountEntity>
    {
        Task<DiscountEntity> GetDiscountUser(string userId);
        Task<int?> GetDiscountIdByName(string name);
    }
}
