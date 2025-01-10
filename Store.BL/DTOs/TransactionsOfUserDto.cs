using Store.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store.BL.DTOs
{
    public class TransactionsOfUserDto
    {
        public List<Transaction> TransactionsOfUser {  get; set; }
        public string PhoneNumber { get; set; }
    }
}
