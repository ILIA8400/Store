﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store.BL.DTOs
{
    public class VerifyCodeDto
    {
        public string PhoneNumber { get; set; }
        public int Code { get; set; }
    }
}
