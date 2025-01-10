using MediatR;
using Store.BL.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store.BL.Features.AdminPanel.Requests.Queries
{
    public class GetOrdersInPanelRequest : IRequest<OrdersInfoDto>
    {
    }
}
