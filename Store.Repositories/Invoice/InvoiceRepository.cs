using Store.DAL;
using Store.Repositories.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store.Repositories.Invoice
{
    public class InvoiceRepository : GenericRepository<Store.Domain.Entities.Invoice>, IInvoiceRepository
    {
        private readonly StoreDbContext storeDbContext;

        public InvoiceRepository(StoreDbContext storeDbContext) : base(storeDbContext)
        {
            this.storeDbContext = storeDbContext;
        }
    }
}
