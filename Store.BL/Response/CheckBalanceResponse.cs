using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Store.BL.Response
{
    public class CheckBalanceResponse
    {
        public bool IsBalance { get; set; }
        public decimal Balance { get; set; }
        public byte? Discount { get; set; }
        public decimal DiscountedAmount { get; set; }
        public decimal TotalAmount { get; set; }
        public int TotalNumberOfProducts { get; set; }
        public string DiscountCode { get; set; }
    }
}
