using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store.BL.DTOs
{
    public class PhoneNumberDto
    {
        [Required(ErrorMessage = "شماره موبایل الزامی است.")]
        [RegularExpression(@"^09\d{9}$", ErrorMessage = "شماره موبایل وارد شده معتبر نیست.")]
        public string PhoneNumber { get; set; }
    }
}
