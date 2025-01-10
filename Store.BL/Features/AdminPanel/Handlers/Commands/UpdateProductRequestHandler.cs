using MediatR;
using Store.BL.Features.AdminPanel.Requests.Commands;
using Store.Domain.Entities;
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
    public class UpdateProductRequestHandler : IRequestHandler<UpdateProductRequest>
    {
        private readonly IProductRepository productRepository;
        private readonly IDiscountRepository discountRepository;
        private readonly IBrandRepository brandRepository;
        private readonly ICategoryRepository categoryRepository;
        private readonly IMediaRepository mediaRepository;

        public UpdateProductRequestHandler(
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

        public async Task Handle(UpdateProductRequest request, CancellationToken cancellationToken)
        {

            #region Update Category
            // Create Or Update Category
            if (!string.IsNullOrEmpty(request.ProductInfoDto.CategoryName))
            {
                var category = await categoryRepository.GetCategoryByName(request.ProductInfoDto.CategoryName);
                if (category == null)
                {
                    categoryRepository.Add(new Domain.Entities.Category()
                    {
                        CategoryName = request.ProductInfoDto.CategoryName,
                        ParentId = 1,
                    });
                }
            } 
            #endregion

            #region Update Brand
            // Create Or Update Brand
            if (!string.IsNullOrEmpty(request.ProductInfoDto.Brand))
            {
                var brand = await brandRepository.GetBrandByName(request.ProductInfoDto.Brand);
                if (brand == null)
                {
                    brandRepository.Add(new Domain.Entities.Brand() { BrandName = request.ProductInfoDto.Brand });
                }
            }
            #endregion

            #region Update Discount
            // گرفتن DiscountId
            int? discountId = await discountRepository.GetDiscountIdByName(request.ProductInfoDto.ProductName);

            // زمانی که قرار است تخفیف آپدیت شود
            if (request.ProductInfoDto.DiscountPercentage != null && request.ProductInfoDto.DiscountPercentage > 0
                && request.ProductInfoDto.DayOfDiscount != null && request.ProductInfoDto.DayOfDiscount > 0)
            {
                if (discountId != null)
                {
                    // ابتدا موجودیت فعلی را از دیتابیس بازیابی کنید
                    var existingDiscount = await discountRepository.GetById(discountId.Value);
                    if (existingDiscount != null)
                    {
                        existingDiscount.DiscountName = request.ProductInfoDto.ProductName;
                        existingDiscount.DiscountPercentage = request.ProductInfoDto.DiscountPercentage;
                        existingDiscount.StartDate = DateTime.Now;
                        existingDiscount.EndDate = DateTime.Now.AddDays(request.ProductInfoDto.DayOfDiscount);

                        discountRepository.Update(existingDiscount);
                    }
                }
                else
                {
                    discountRepository.Add(new Domain.Entities.Discount()
                    {
                        DiscountName = request.ProductInfoDto.ProductName,
                        DiscountPercentage = request.ProductInfoDto.DiscountPercentage,
                        StartDate = DateTime.Now,
                        EndDate = DateTime.Now.AddDays(request.ProductInfoDto.DayOfDiscount),
                    });
                }
            }

            // زمانی که کاربر می‌خواهد تخفیف را حذف کند
            if (request.ProductInfoDto.DiscountPercentage != null && request.ProductInfoDto.DiscountPercentage == 0
                && request.ProductInfoDto.DayOfDiscount != null && request.ProductInfoDto.DayOfDiscount == 0)
            {
                if (discountId != null)
                {
                    var existingDiscount = await discountRepository.GetById(discountId.Value);
                    if (existingDiscount != null)
                    {
                        discountRepository.Delete(existingDiscount);
                    }
                }
            }
            #endregion

            await brandRepository.SaveChange();

            discountId = await discountRepository.GetDiscountIdByName(request.ProductInfoDto.ProductName);

            #region Update Product
            var product = await productRepository.GetById(request.ProductInfoDto.ProductId);
            if (!string.IsNullOrEmpty(request.ProductInfoDto.ProductName))
            {
                product.ProductName = request.ProductInfoDto.ProductName;
            }

            if (!string.IsNullOrEmpty(request.ProductInfoDto.ProductDescription))
            {
                product.Description = request.ProductInfoDto.ProductDescription;
            }

            if (request.ProductInfoDto.AvaillableQuentity != null && request.ProductInfoDto.AvaillableQuentity >= 0)
            {
                product.AvaillableQuentity = request.ProductInfoDto.AvaillableQuentity;
            }

            if (request.ProductInfoDto.Price != null && request.ProductInfoDto.Price > 0)
            {
                product.Price = request.ProductInfoDto.Price;
            }

            var brandId = (await brandRepository.GetBrandByName(request.ProductInfoDto.Brand)).BrandId;
            var categoryId = (await categoryRepository.GetCategoryByName(request.ProductInfoDto.CategoryName)).CategoryId;

            product.CategoryId = categoryId;
            product.BrandId = brandId;
            product.DiscountId = discountId;

            await productRepository.SaveChange();
            #endregion

            #region Save New Image
            if (request.FormFile != null && request.FormFile.Length > 0)
            {
                // مسیر ذخیره‌سازی فایل
                var filePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "images", request.FormFile.FileName);

                // چک کردن وجود فایل
                if (File.Exists(filePath))
                {
                    //// فایل وجود دارد، می‌توانید خطای مناسب بدهید
                    //throw new Exception("A file with the same name already exists.");

                    File.Delete(filePath); // حذف فایل
                }

                var media = await mediaRepository.GetByProductId(request.ProductInfoDto.ProductId);
                media.Path = request.FormFile.FileName; 

                await brandRepository.SaveChange();

                // ذخیره فایل
                using (var fileStream = new FileStream(filePath, FileMode.Create))
                {
                    await request.FormFile.CopyToAsync(fileStream);
                }
            } 
            #endregion


        }
    }
}
