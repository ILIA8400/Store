using Store.DAL.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store.Domain.Entities
{
    public class Address
    {
        public int AddressId { get; set; }
        public string UserAddress { get; set; }
        public string City { get; set; }
        public string PostalCode { get; set; }
        public string UserId { get; set; }

        #region Navigations
        public ApplicationUser User { get; set; }
        public List<Invoice> Invoices { get; set; } 
        #endregion
    }
}
