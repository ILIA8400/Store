using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store.Domain.Entities
{
    public class Product
    {
        public int ItemId { get; set; }
        public int ShoppingCartId { get; set; }
        public int ProductId { get; set; }
        public byte Number { get; set; }
    }
}
