using Microsoft.EntityFrameworkCore;
using Store.DAL;
using Store.Repositories.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BrandEntity = Store.Domain.Entities.Brand;

namespace Store.Repositories.Brand
{
    public class BrandRepository : GenericRepository<BrandEntity>,IBrandRepository
    {
        private readonly StoreDbContext storeDbContext;

        public BrandRepository(StoreDbContext storeDbContext) : base(storeDbContext)
        {
            this.storeDbContext = storeDbContext;
        }

        public async Task<BrandEntity> GetBrandByName(string name)
        {
            return await storeDbContext.Brands.SingleOrDefaultAsync(x=>x.BrandName == name);
        }

        public async Task<List<BrandEntity>> GetBrandsByCategoryId(int categoryId)
        {
            // 1. تمام دسته‌بندی‌ها را از پایگاه داده بارگذاری می‌کنیم
            var allCategories = await storeDbContext.Categories.ToListAsync();

            // 2. تعریف یک متد بازگشتی برای پیدا کردن تمام دسته‌های زیرمجموعه
            List<int> GetSubCategoryIds(int parentId)
            {
                return allCategories
                    .Where(c => c.ParentId == parentId)
                    .Select(c => c.CategoryId)
                    .Concat(allCategories.Where(c => c.ParentId == parentId)
                        .SelectMany(c => GetSubCategoryIds(c.CategoryId)))
                    .ToList();
            }

            // 3. پیدا کردن همه زیرمجموعه‌ها به علاوه خود دسته‌بندی
            var categoryIds = GetSubCategoryIds(categoryId);
            categoryIds.Add(categoryId); // اضافه کردن دسته‌بندی اصلی

            // 4. فیلتر محصولات با CategoryIdهای شناسایی شده و گرفتن برندها
            var result = await storeDbContext.Products
                .Include(x => x.Braand)
                .Where(x => categoryIds.Contains(x.CategoryId)) // فیلتر کردن براساس دسته‌ها
                .Select(x => x.Braand) // انتخاب برندها
                .GroupBy(b => b.BrandId) // حذف تکراری‌ها بر اساس Id برند
                .Select(g => g.First()) // انتخاب اولین رکورد از هر گروه
                .ToListAsync();

            // 5. بازگرداندن لیست برندهای منحصربه‌فرد
            return result;
        }
    }
}
