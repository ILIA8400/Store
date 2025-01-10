using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store.BL.DTOs
{
    public class ProductInfoDto
    {
        public int ProductId { get; set; }
        public string ProductName { get; set; }
        public string ProductDescription { get; set; }
        public decimal Price { get; set; }
        public string Path { get; set; }
        public int AvaillableQuentity { get; set; }
        public string CategoryName { get; set; }
        public byte DiscountPercentage { get; set; }
        public string Brand { get; set; }
        public int DayOfDiscount { get; set; }

        public List<ProductInfoDto> Products { get; set; }
    }
}
