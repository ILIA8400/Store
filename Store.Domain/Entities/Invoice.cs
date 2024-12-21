using Store.DAL.Identity;
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
        public int DiscountId { get; set; }
        public Discount Discount { get; set; }
        public List<InvoiceItem> InvoiceItems { get; set; }
        public string UserId { get; set; }
        public ApplicationUser AplicationUser { get; set; }
    }
}
