using Kavenegar;
using MediatR;
using Microsoft.Extensions.Caching.Memory;
using Store.BL.Features.Register.Requests.Queries;
using Store.BL.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Store.BL.Features.Register.Handlers.Queries
{
    public class VerifyCodeHandler : IRequestHandler<VerifyCodeRequest, VerifyCodeResponse>
    {
        private readonly IMemoryCache memoryCache;

        public VerifyCodeHandler(IMemoryCache memoryCache) 
        {
            this.memoryCache = memoryCache;
        }
        public async Task<VerifyCodeResponse> Handle(VerifyCodeRequest request, CancellationToken cancellationToken)
        {
            var api = new KavenegarApi("464D75325753483974524F484E494A6C4D50776C564C676B2B3859455664624E43384D6759706E476F69383D");
            Random rand = new Random();
            var code = rand.Next(5000, 10000);
            string message = $"کد تایید شما : {code}";

            try
            {
                //var result = await api.Send("2000660110", request.PhoneNumberDto.PhoneNumber, message);
                memoryCache.Set(request.PhoneNumberDto.PhoneNumber, code, TimeSpan.FromSeconds(200));
                return new VerifyCodeResponse() { Message = "Code" };
                //if (result.Status == 200)
                //{
                //    return new VerifyCodeResponse() { Result = 1};
                //}
                //else return new VerifyCodeResponse() { Result = -1 };
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
