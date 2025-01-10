using MediatR;
using Store.BL.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store.BL.Features.AdminPanel.Requests.Commands
{
    public class DeleteProductRequestCommand : IRequest
    {
        public ProductInfoDto ProductInfoDto { get; set; }
    }
}
