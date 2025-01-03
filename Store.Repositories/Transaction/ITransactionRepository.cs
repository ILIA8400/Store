using Store.Repositories.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store.Repositories.Transaction
{
    public interface ITransactionRepository : IGenericRepository<Domain.Entities.Transaction>
    {
        Task<decimal> GetIncome();
    }
}
