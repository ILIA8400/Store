using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store.BL.DTOs
{
    public class AdminPanelDto
    {
        public ReportsDto ReportsDto { get; set; }
        public OrdersInfoDto OrdersInfoDto { get; set; }
        public ProductsInfoDto ProductsInfoDto { get; set; }
        public UsersInfoDto UsersInfoDto { get; set; }
        public AdminsInfoDto AdminsInfoDto { get; set; }
    }
}
