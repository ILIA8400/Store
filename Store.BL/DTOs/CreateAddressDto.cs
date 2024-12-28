using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store.BL.DTOs
{
    public class CreateAddressDto
    {
        public string City { get; set; }
        public string Address { get; set; }
        public string PostalCode { get; set; }
    }
}
