using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store.Domain.Entities
{
    public class InvoiceItem
    {
        public int InvoiceItemId { get; set; }
        public int ProductId { get; set; }
        public int InvoiceId { get; set; }
        public int Quentity { get; set; }

        #region Navigations
        public Invoice Invoice { get; set; }
        public Product Product { get; set; } 
        #endregion
    }
}
