using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store.BL.DTOs
{
    public class BasketItemDto
    {
        public int Quentity { get; set; }
        public int ProductId { get; set; }
        public string UserName { get; set; }
    }
}
