using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store.BL.DTOs
{
    public class OrderInfoDto
    {
        public decimal TotalAmount { get; set; }
        public DateTime DateTime { get; set; }
        public int NumberOfItem { get; set; }
        public string PhoneNumber { get; set; }
    }
}
