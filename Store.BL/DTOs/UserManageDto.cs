using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store.BL.DTOs
{
    public class UserManageDto
    {
        public string UserId { get; set; }
        public string PhoneNumber { get; set; }
        public decimal? Balance { get; set; }
    }
}
