using MediatR;
using Microsoft.AspNetCore.Identity;
using Store.BL.Features.Discount.Requests.Commands;
using Store.BL.Response;
using Store.DAL.Identity;
using Store.Repositories.Discount;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store.BL.Features.Discount.Handlers.Commands
{
    public class ApplyDiscountCodeCommandHandler : IRequestHandler<ApplyDiscountCodeCommandRequest, CheckBalanceResponse>
    {
        private readonly IDiscountRepository discountRepository;

        public ApplyDiscountCodeCommandHandler(IDiscountRepository discountRepository)
        {
            this.discountRepository = discountRepository;
        }

        public async Task<CheckBalanceResponse> Handle(ApplyDiscountCodeCommandRequest request, CancellationToken cancellationToken)
        {
            var discountUser = await discountRepository.GetDiscountUser(request.UserId);
            if (discountUser == null)
            {
                throw new Exception("کاربر هیچ تخفیفی ندارد");
            }

            if (discountUser.Code != request.CheckBalanceResponse.DiscountCode)
            {
                throw new Exception("کد تخفیف اشتباه است");
            }
            else
            {
                request.CheckBalanceResponse.DiscountCode = "";
                request.CheckBalanceResponse.Discount = discountUser.DiscountPercentage;
                request.CheckBalanceResponse.DiscountedAmount =
                    request.CheckBalanceResponse.TotalAmount * ((decimal) request.CheckBalanceResponse.Discount / 100);
                return request.CheckBalanceResponse;
            }          
          
        }
    }
}
