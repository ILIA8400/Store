using Store.BL.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store.BL.DTOs
{
    public class AddressPageDto
    {
        public List<AddressInfoResponse> AddressInfoResponses {  get; set; }

        public string City { get; set; }
        public string Address { get; set; }
        public string PostalCode { get; set; }

    }
}
