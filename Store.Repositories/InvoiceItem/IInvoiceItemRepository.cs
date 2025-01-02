using Store.Domain.Entities;
using Store.Repositories.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store.Repositories.InvoiceItem
{
    public interface IInvoiceItemRepository : IGenericRepository<Store.Domain.Entities.InvoiceItem>
    {
        Task<List<Store.Domain.Entities.InvoiceItem>> GetInvoiceItemWithUserId(string userId);
    }
}
