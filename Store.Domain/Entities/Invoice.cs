using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store.Domain.Entities
{
    public class Invoice
    {
        public int InvoiceId { get; set; }
        public DateTime DateTime { get; set; }
        public int NumberOfItem { get; set; }
        public decimal TotalAmount { get; set; }
        public int AddressId { get; set; }
        public Address Address { get; set; }
        public int ShoppingCartId { get; set; }
        public ShoppingCart ShoppingCart { get; set; }
    }
}
