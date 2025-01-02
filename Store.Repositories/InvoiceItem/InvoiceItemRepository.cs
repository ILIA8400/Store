using Microsoft.EntityFrameworkCore;
using Store.DAL;
using Store.Domain.Entities;
using Store.Repositories.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store.Repositories.InvoiceItem
{
    public class InvoiceItemRepository : GenericRepository<Store.Domain.Entities.InvoiceItem>, IInvoiceItemRepository
    {
        private readonly StoreDbContext storeDbContext;

        public InvoiceItemRepository(StoreDbContext storeDbContext) : base(storeDbContext)
        {
            this.storeDbContext = storeDbContext;
        }

        public async Task<List<Domain.Entities.InvoiceItem>> GetInvoiceItemWithUserId(string userId)
        {
            var basket = await storeDbContext.Baskets.Where(x => x.UserId == userId).Include(x => x.BasketItems)
                .ThenInclude(x=>x.Product).SingleOrDefaultAsync();
                
            var invoiceItems = new List<Domain.Entities.InvoiceItem>();
            foreach (var basketItems in basket.BasketItems)
            {
                invoiceItems.Add(new Domain.Entities.InvoiceItem
                {
                    Quentity = basketItems.Quentity,
                    ProductId = basketItems.ProductId,
                });
            }

            return invoiceItems;
        }
    }
}
