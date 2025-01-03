using MediatR;
using Microsoft.AspNetCore.Identity;
using Store.BL.Features.AdminPanel.Requests.Queries;
using Store.BL.Response;
using Store.DAL.Identity;
using Store.Repositories.Invoice;
using Store.Repositories.Transaction;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store.BL.Features.AdminPanel.Handlers.Queries
{
    public class GetInfoAdminPanelHandler : IRequestHandler<GetInfoAdminPanelRequest, AdminPanelInfoResponse>
    {
        private readonly ITransactionRepository transactionRepository;
        private readonly UserManager<ApplicationUser> userManager;
        private readonly IInvoiceRepository invoiceRepository;

        public GetInfoAdminPanelHandler(ITransactionRepository transactionRepository,UserManager<ApplicationUser> userManager,IInvoiceRepository invoiceRepository)
        {
            this.transactionRepository = transactionRepository;
            this.userManager = userManager;
            this.invoiceRepository = invoiceRepository;
        }
        public async Task<AdminPanelInfoResponse> Handle(GetInfoAdminPanelRequest request, CancellationToken cancellationToken)
        {
            var numberOfUsers = userManager.Users.Count();
            var numberOfOrders = await invoiceRepository.GetNumberOfOrders();
            var income = await transactionRepository.GetIncome();

            return new AdminPanelInfoResponse
            {
                NumberOfUsers = numberOfUsers,
                Income = income,
                NumberOfOrders = numberOfOrders
            };
        }
    }
}
