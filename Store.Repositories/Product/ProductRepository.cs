using Store.DAL;
using ProductEntity = Store.Domain.Entities.Product;
using Store.Repositories.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace Store.Repositories.Product
{
    public class ProductRepository : GenericRepository<ProductEntity>, IProductRepository
    {
        private readonly StoreDbContext storeDbContext;

        public ProductRepository(StoreDbContext storeDbContext) : base(storeDbContext)
        {
            this.storeDbContext = storeDbContext;
        }

        public async Task<List<ProductEntity>> GetProductByCategoryAndBrand(int categoryId, int brandId)
        {
            // اگر CategoryId صفر باشد، فقط براساس BrandId فیلتر می‌کنیم
            if (categoryId == 0)
            {
                if (brandId == 0)
                {
                    // اگر هم برند صفر باشد، تمام محصولات لود شوند
                    return await storeDbContext.Products.Include(x => x.Medias)
                        .Include(p => p.Braand) // بارگذاری برند مرتبط
                        .ToListAsync();
                }

                // اگر فقط برند انتخاب شده باشد
                var productsByBrand = await storeDbContext.Products.Include(x => x.Medias)
                    .Include(p => p.Braand) // بارگذاری برند مرتبط
                    .Where(p => p.Braand.BrandId == brandId) // فیلتر محصولات براساس برند
                    .ToListAsync();

                return productsByBrand; // بازگرداندن محصولات فیلترشده بر اساس برند
            }

            // اگر CategoryId صفر نباشد، ابتدا تمام دسته‌بندی‌ها و زیرمجموعه‌های آن را پیدا می‌کنیم
            var allCategories = await storeDbContext.Categories.ToListAsync();

            List<int> GetSubCategoryIds(int parentId)
            {
                return allCategories
                    .Where(c => c.ParentId == parentId)
                    .Select(c => c.CategoryId)
                    .Concat(allCategories.Where(c => c.ParentId == parentId)
                        .SelectMany(c => GetSubCategoryIds(c.CategoryId)))
                    .ToList();
            }

            var categoryIds = GetSubCategoryIds(categoryId);
            categoryIds.Add(categoryId); // اضافه کردن خود دسته‌بندی اصلی

            // اگر برند صفر باشد فقط دسته‌بندی‌ها فیلتر می‌شوند
            if (brandId == 0)
            {
                var productsByCategory = await storeDbContext.Products.Include(x => x.Medias)
                    .Include(p => p.Braand) // بارگذاری برند مرتبط
                    .Where(p => categoryIds.Contains(p.CategoryId)) // فیلتر دسته‌بندی
                    .ToListAsync();

                return productsByCategory; // بازگرداندن محصولات بر اساس دسته‌بندی
            }

            // فیلتر محصولات براساس دسته‌بندی و برند
            var products = await storeDbContext.Products.Include(x => x.Medias)
                .Include(p => p.Braand) // بارگذاری برند مرتبط
                .Where(p => categoryIds.Contains(p.CategoryId) && p.Braand.BrandId == brandId) // فیلتر دسته‌بندی و برند
                .ToListAsync();

            return products; // بازگرداندن محصولات
        }


        public async Task<List<ProductEntity>> GetProductByCategoryId(int categoryId)
        {
            // 1. بارگذاری همه دسته‌بندی‌ها از پایگاه داده
            var allCategories = await storeDbContext.Categories.ToListAsync();

            // 2. متد بازگشتی برای پیدا کردن دسته‌بندی‌های زیرمجموعه
            List<int> GetSubCategoryIds(int parentId)
            {
                return allCategories
                    .Where(c => c.ParentId == parentId)
                    .Select(c => c.CategoryId)
                    .Concat(allCategories.Where(c => c.ParentId == parentId)
                        .SelectMany(c => GetSubCategoryIds(c.CategoryId)))
                    .ToList();
            }

            // 3. جمع‌آوری تمام دسته‌بندی‌های مربوط به دسته‌بندی اصلی
            var categoryIds = GetSubCategoryIds(categoryId);
            categoryIds.Add(categoryId); // اضافه کردن دسته‌بندی اصلی

            // 4. لود کردن محصولات بر اساس دسته‌بندی‌ها
            var products = await storeDbContext.Products.Include(x=>x.Medias)
                .Include(p => p.Braand) // لود برند مرتبط (در صورت نیاز)
                .Where(p => categoryIds.Contains(p.CategoryId)) // فیلتر براساس دسته‌بندی‌ها
                .ToListAsync();

            // 5. بازگرداندن لیست محصولات
            return products;
        }

        public override async Task<IEnumerable<ProductEntity>> GetAll()
        {
            var products = await storeDbContext.Products.Include(x => x.Medias).ToListAsync();
            return products;
        }
    }
}
