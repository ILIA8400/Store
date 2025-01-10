using Microsoft.EntityFrameworkCore;
using Store.DAL;
using Store.Domain.Entities;
using Store.Repositories.Common;
using Store.Repositories.Product;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WalletEntity = Store.Domain.Entities.Wallet;

namespace Store.Repositories.Wallet
{
    public class WalletRepository : GenericRepository<WalletEntity>, IWalletRepository
    {
        private readonly StoreDbContext shopDbContext;

        public WalletRepository(StoreDbContext shopDbContext) : base(shopDbContext)
        {
            this.shopDbContext = shopDbContext;
        }

        public async Task<decimal> GetBalanceByUserId(string userId)
        {
            return (await shopDbContext.Wallets.Where(u => u.UserId == userId).SingleOrDefaultAsync()).Balance;
        }

        public async Task<WalletEntity> GetWalletByUserAndDisount(string userId)
        {
            return await shopDbContext.Wallets.Where(x => x.UserId == userId)
                .Include(x => x.User).ThenInclude(x=>x.Discount)
                .SingleOrDefaultAsync();
        }

        public async Task<WalletEntity> GetWalletByUserId(string userId)
        {
            return await shopDbContext.Wallets.Where(x=>x.UserId == userId).SingleOrDefaultAsync();
        }

        public async Task<bool> IncreaseBalance(string userId, decimal amount)
        {
            try
            {
                var wallet = await shopDbContext.Wallets.Where(x => x.UserId == userId).SingleOrDefaultAsync();
                wallet.Balance += amount;

                var newTransaction = new Domain.Entities.Transaction
                {
                    Amount = amount,
                    DateTime = DateTime.Now,
                    TransactionStatus = Domain.Enum.TransactionStatus.Successed,
                    TransactionType = 1,
                    WalletId = wallet.WalletId,
                };

                if (wallet.Transactions == null)
                {
                    wallet.Transactions = new List<Domain.Entities.Transaction>();
                }
                wallet.Transactions.Add(newTransaction);
                shopDbContext.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }

           
        }

        public async Task UpdateBalanceWithPhoneNumber(string phoneNumber, decimal newBalance)
        {
            var userId = (await shopDbContext.Users.SingleOrDefaultAsync(x => x.PhoneNumber == phoneNumber)).Id;
            var wallet = await shopDbContext.Wallets.SingleOrDefaultAsync(x => x.UserId == userId);
            wallet.Balance = newBalance;

            await shopDbContext.SaveChangesAsync();
        }
    }
}
