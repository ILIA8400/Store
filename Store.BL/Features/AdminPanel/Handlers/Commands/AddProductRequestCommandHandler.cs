using MediatR;
using Store.BL.Features.AdminPanel.Requests.Commands;
using Store.Repositories.Brand;
using Store.Repositories.Category;
using Store.Repositories.Discount;
using Store.Repositories.Media;
using Store.Repositories.Product;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store.BL.Features.AdminPanel.Handlers.Commands
{
    public class AddProductRequestCommandHandler : IRequestHandler<AddProductRequestCommand>
    {
        private readonly IProductRepository productRepository;
        private readonly IDiscountRepository discountRepository;
        private readonly IBrandRepository brandRepository;
        private readonly ICategoryRepository categoryRepository;
        private readonly IMediaRepository mediaRepository;

        public AddProductRequestCommandHandler(
            IProductRepository productRepository,
            IDiscountRepository discountRepository,
            IBrandRepository brandRepository,
            ICategoryRepository categoryRepository,
            IMediaRepository mediaRepository
            )
        {
            this.productRepository = productRepository;
            this.discountRepository = discountRepository;
            this.brandRepository = brandRepository;
            this.categoryRepository = categoryRepository;
            this.mediaRepository = mediaRepository;
        }

        public async Task Handle(AddProductRequestCommand request, CancellationToken cancellationToken)
        {
            brandRepository.Add(new Domain.Entities.Brand() { BrandName = request.ProductInfoDto.Brand});

            categoryRepository.Add(new Domain.Entities.Category()
            {
                CategoryName = request.ProductInfoDto.CategoryName,
                ParentId = 1,
            });

            int? discountId = null;

            if (request.ProductInfoDto.DiscountPercentage != null && request.ProductInfoDto.DiscountPercentage > 0 
                && request.ProductInfoDto.DayOfDiscount != null && request.ProductInfoDto.DayOfDiscount > 0)
            {
                discountRepository.Add(new Domain.Entities.Discount()
                {
                    DiscountName = request.ProductInfoDto.ProductName,
                    DiscountPercentage = request.ProductInfoDto.DiscountPercentage,
                    StartDate = DateTime.Now,
                    EndDate = DateTime.Now.AddDays(request.ProductInfoDto.DayOfDiscount),
                });

                discountId = await discountRepository.GetDiscountIdByName(request.ProductInfoDto.ProductName);
            }

            await brandRepository.SaveChange();

            var brandId = (await brandRepository.GetBrandByName( request.ProductInfoDto.Brand )).BrandId;
            var categoryId = (await categoryRepository.GetCategoryByName( request.ProductInfoDto.CategoryName)).CategoryId;

            productRepository.Add(new Domain.Entities.Product()
            {
                AvaillableQuentity = request.ProductInfoDto.AvaillableQuentity,
                Price = request.ProductInfoDto.Price,
                ProductName = request.ProductInfoDto.ProductName,
                Description = request.ProductInfoDto.ProductDescription,
                BrandId = brandId,
                CategoryId = categoryId,
                DiscountId = discountId,
                IsDeleted = false,
            });

            await brandRepository.SaveChange();

            var productId = (await productRepository.GetByName( request.ProductInfoDto.ProductName )).ProductId;

            mediaRepository.Add(new Domain.Entities.Media
            {
                Path = request.FormFile.FileName,  
                ProductId = productId,
            });

            await brandRepository.SaveChange();

            if (request.FormFile != null && request.FormFile.Length > 0)
            {
                // مسیر ذخیره‌سازی فایل
                var filePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "images", request.FormFile.FileName);

                // ذخیره فایل
                using (var fileStream = new FileStream(filePath, FileMode.Create))
                {
                    await request.FormFile.CopyToAsync(fileStream);
                }
            }
                
        }
    }
}
