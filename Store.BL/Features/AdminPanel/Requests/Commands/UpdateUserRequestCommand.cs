using MediatR;
using Store.BL.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store.BL.Features.AdminPanel.Requests.Commands
{
    public class UpdateUserRequestCommand : IRequest
    {
        public UsersInfoDto UsersInfoDto { get; set; }
        public string OldPhoneNumber { get; set; }
    }
}
