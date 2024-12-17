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
    }
}
