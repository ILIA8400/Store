using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store.BL.Features.AdminPanel.Requests.Commands
{
    public class DeleteUserRequestCommand : IRequest
    {
        public string PhoneNumber { get; set; }
    }
}
