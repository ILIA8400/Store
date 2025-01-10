using Store.DAL.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store.BL.DTOs
{
    public class UsersInfoDto
    {
        public List<UserManageDto> Admins { get; set; }
        public List<UserManageDto> NormalUsers { get; set; }

        public string? PhoneNumber { get; set; }
        public decimal? Balance { get; set; }

    }
}
