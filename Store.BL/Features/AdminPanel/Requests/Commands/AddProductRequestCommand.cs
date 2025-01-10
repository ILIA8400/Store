using MediatR;
using Microsoft.AspNetCore.Http;
using Store.BL.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store.BL.Features.AdminPanel.Requests.Commands
{
    public class AddProductRequestCommand : IRequest
    {
        public ProductInfoDto ProductInfoDto { get; set; }
        public IFormFile FormFile { get; set; }
    }
}
