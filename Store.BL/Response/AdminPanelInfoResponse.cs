using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store.BL.Response
{
    public class AdminPanelInfoResponse
    {
        public decimal Income { get; set; }
        public int NumberOfOrders { get; set; }
        public int NumberOfUsers { get; set; }
    }
}
