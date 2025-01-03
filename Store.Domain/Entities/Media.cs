using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store.Domain.Entities
{
    public class Media
    {
        public int MediaId { get; set; }
        public int ProductId { get; set; }
        public string Path {  get; set; }

        #region Navigations
        public Product Product { get; set; } 
        #endregion

    }
}
