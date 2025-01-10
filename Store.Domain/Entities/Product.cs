using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store.Domain.Entities
{
    public class Product
    {
        public int ProductId { get; set; }
        public string ProductName { get; set; }
        public string Description { get; set; }
        public int CategoryId { get; set; }
        public decimal Price { get; set; }
        public int BrandId { get; set; }
        public int AvaillableQuentity {  get; set; }
        public int? DiscountId { get; set; }
        public bool IsDeleted { get; set; } = false;

        #region Navigations
        public Discount? Discount { get; set; }
        public Brand Braand { get; set; }
        public List<Media>? Medias { get; set; }
        public List<BasketItem>? BasketItems { get; set; }
        public Category Category { get; set; }
        public List<InvoiceItem>? InvoiceItems { get; set; } 
        #endregion


    }
}
