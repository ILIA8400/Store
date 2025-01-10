using Store.DAL.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store.Domain.Entities
{
    public class Discount
    {
        public int DiscountId { get; set; }
        public string? DiscountName { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public string? Code { get; set; }
        public decimal? DiscountCeiling { get; set; }
        public byte DiscountPercentage { get; set; }
    }
}
