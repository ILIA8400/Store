using Store.DAL;
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
        public WalletRepository(StoreDbContext shopDbContext) : base(shopDbContext) { }
    }
}
