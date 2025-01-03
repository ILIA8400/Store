using Store.Domain.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store.Domain.Entities
{
    public class Transaction
    {
        public int TransactionId { get; set; }
        public int WalletId { get; set; }
        public TransactionStatus TransactionStatus { get; set; }
        public int TransactionType { get; set; }
        public decimal Amount { get; set; }
        public DateTime DateTime { get; set; }

        #region Navigations
        public Wallet Wallet { get; set; } 
        #endregion
    }
}
