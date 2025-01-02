using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store.BL.Response
{
    public class AddressInfoResponse
    {
        public int Id { get; set; }
        public string City { get; set; }
        public string Address { get; set; }
        public string PostalCode { get; set; }
        public bool IsDefaultAddress { get; set; }

    }
}
