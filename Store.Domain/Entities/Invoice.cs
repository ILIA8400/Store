using Store.DAL.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
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
        public int? DiscountId { get; set; }
        public string ApplicationUserId { get; set; }
        public int AddressId { get; set; }

        #region Navigations
        public Address Address { get; set; }
        public ApplicationUser ApplicationUser { get; set; }
        public List<InvoiceItem> InvoiceItems { get; set; }
        public Discount? Discount { get; set; }
        #endregion
    }

}
