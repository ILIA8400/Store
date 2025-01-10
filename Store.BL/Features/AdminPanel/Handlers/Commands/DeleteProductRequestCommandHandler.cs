using MediatR;
using Store.BL.Features.AdminPanel.Requests.Commands;
using Store.Repositories.Product;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store.BL.Features.AdminPanel.Handlers.Commands
{
    public class DeleteProductRequestCommandHandler : IRequestHandler<DeleteProductRequestCommand>
    {
        private readonly IProductRepository productRepository;

        public DeleteProductRequestCommandHandler(IProductRepository productRepository)
        {
            this.productRepository = productRepository;
        }
        public async Task Handle(DeleteProductRequestCommand request, CancellationToken cancellationToken)
        {
            var product = await productRepository.GetById(request.ProductInfoDto.ProductId);
            if (product != null)
            {
                product.IsDeleted = true;
            }
            await productRepository.SaveChange();
        }
    }
}
