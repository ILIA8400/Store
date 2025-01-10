using Microsoft.EntityFrameworkCore;
using Store.DAL;
using Store.Repositories.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store.Repositories.Transaction
{
    public class TransactionRepository : GenericRepository<Domain.Entities.Transaction>, ITransactionRepository
    {
        private readonly StoreDbContext storeDbContext;

        public TransactionRepository(StoreDbContext storeDbContext) : base(storeDbContext)
        {
            this.storeDbContext = storeDbContext;
        }

        public async Task<decimal> GetIncome()
        {
            var amounts = storeDbContext.Transactions.Where(x=>x.TransactionType == 1).Select(x=>x.Amount).ToList();
            decimal income = 0;

            foreach (var item in amounts)
            {
                income += item;
            }

            return income;
        }

        public async Task<List<Domain.Entities.Transaction>> GetAllTransactionsOfUser(string userId)
        {
            var result = await storeDbContext.Wallets
                .Where(x => x.UserId == userId)
                .Include(x => x.Transactions)
                .SelectMany(x => x.Transactions) // فلت کردن تراکنش‌ها
                .ToListAsync();

            return result;
        }

    }
}
