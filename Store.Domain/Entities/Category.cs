using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store.Domain.Entities
{
    public class Category
    {
        public int CategoryId { get; set; }
        public string CategoryName { get; set; }
        public int? ParentId { get; set; }

        #region Navigations
        public Category? Parent { get; set; }
        public List<Product>? Products { get; set; } 
        #endregion
    }
}
