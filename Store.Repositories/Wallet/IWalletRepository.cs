using WalletEntity = Store.Domain.Entities.Wallet;
using Store.Repositories.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store.Repositories.Wallet
{
    public interface IWalletRepository : IGenericRepository<WalletEntity>
    {
        Task<WalletEntity> GetWalletByUserId(string userId);
        Task<WalletEntity> GetWalletByUserAndDisount(string userId);
        Task<decimal> GetBalanceByUserId(string userId);
        Task<bool> IncreaseBalance(string userId,decimal amount);
        Task UpdateBalanceWithPhoneNumber(string phoneNumber,decimal newBalance);
    }
}
