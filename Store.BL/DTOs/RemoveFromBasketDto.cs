﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store.BL.DTOs
{
    public class RemoveFromBasketDto
    {
        public string UserId { get; set; }
        public int ProductId { get; set; }
    }
}
