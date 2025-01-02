using DiscountEntity = Store.Domain.Entities.Discount;
using Store.Repositories.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Store.DAL;
using Microsoft.EntityFrameworkCore;

namespace Store.Repositories.Discount
{
    public class DiscountRepository : GenericRepository<DiscountEntity>, IDiscountRepository
    {
        private readonly StoreDbContext storeDbContext;

        public DiscountRepository(StoreDbContext storeDbContext) : base(storeDbContext)
        {
            this.storeDbContext = storeDbContext;
        }

        public async Task<DiscountEntity> GetDiscountUser(string userId)
        {
            return (await storeDbContext.Users.Include(x=>x.Discount).Where(x=>x.Id == userId).SingleOrDefaultAsync()).Discount;
        }
    }
}
