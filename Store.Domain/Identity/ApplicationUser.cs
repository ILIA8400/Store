using Microsoft.AspNetCore.Identity;
using Store.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store.DAL.Identity
{
    public class ApplicationUser : IdentityUser
    {
        public int? DiscountId { get; set; }
        public Discount? Discount { get; set; }
        public List<Address>? Addresses { get; set; }
        public List<Invoice>? Invoices { get; set; }
        public int DefaultAddressId { get; set; }
    }
}
