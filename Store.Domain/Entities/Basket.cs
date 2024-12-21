using Store.DAL.Identity;
using Store.Domain.Enum;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store.Domain.Entities
{
    public class Basket
    {
        public int BasketId { get; set; }
        public OrederStatus Status { get; set; } = OrederStatus.Reset;
        public decimal TotalAmount { get; set; }
        public string Description { get; set; }
        public string UserId { get; set; }
        public ApplicationUser User { get; set; }
        public List<BasketItem>? BasketItems { get; set; }
    }
}
