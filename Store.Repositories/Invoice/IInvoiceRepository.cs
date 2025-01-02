using Store.Domain.Entities;
using Store.Repositories.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store.Repositories.Invoice
{
    public interface IInvoiceRepository : IGenericRepository<Store.Domain.Entities.Invoice>
    {
    }
}
