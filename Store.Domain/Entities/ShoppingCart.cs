using Store.DAL.Identity;
using Store.Domain.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store.Domain.Entities
{
    public class ShoppingCart
    {
        public int ShoppingCartId { get; set; }
        public OrederStatus Status { get; set; } = OrederStatus.Reset;
        public decimal TotalAmount { get; set; }
        public string Description { get; set; }
        public int UserId { get; set; }
        public ApplicationUser User { get; set; }
    }
}
