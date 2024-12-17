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
        public Wallet Wallet { get; set; }
        public TransactionStatus TransactionStatus { get; set; }
        public byte TransactionType { get; set; }
        public long Amount { get; set; }
        public DateTime DateTime { get; set; }
    }
}
