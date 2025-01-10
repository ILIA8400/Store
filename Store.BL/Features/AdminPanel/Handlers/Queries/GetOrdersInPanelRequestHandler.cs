using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Store.BL.DTOs;
using Store.BL.Features.AdminPanel.Requests.Queries;
using Store.DAL.Identity;
using Store.Repositories.Invoice;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store.BL.Features.AdminPanel.Handlers.Queries
{
    public class GetOrdersInPanelRequestHandler : IRequestHandler<GetOrdersInPanelRequest, OrdersInfoDto>
    {
        private readonly IInvoiceRepository invoiceRepository;
        private readonly UserManager<ApplicationUser> userManager;

        public GetOrdersInPanelRequestHandler(IInvoiceRepository invoiceRepository,UserManager<ApplicationUser> userManager)
        {
            this.invoiceRepository = invoiceRepository;
            this.userManager = userManager;
        }
        public async Task<OrdersInfoDto> Handle(GetOrdersInPanelRequest request, CancellationToken cancellationToken)
        {
            var orders = new OrdersInfoDto();
            orders.OrderInfoDtos = new List<OrderInfoDto>();
            var users = (await userManager.Users.Include(x => x.Invoices).ToListAsync());
            foreach (var user in users)
            {                
                if (user.Invoices.Any())
                {           
                    foreach (var invoice in user.Invoices)
                    {
                        var orderInfoDto = new OrderInfoDto();
                        orderInfoDto.PhoneNumber = user.PhoneNumber;
                        orderInfoDto.NumberOfItem = invoice.NumberOfItem;
                        orderInfoDto.TotalAmount = invoice.TotalAmount;
                        orderInfoDto.DateTime = invoice.DateTime;
                        orders.OrderInfoDtos.Add(orderInfoDto);
                    }                   
                } 
                
            }

            return orders;
        }
    }
}
