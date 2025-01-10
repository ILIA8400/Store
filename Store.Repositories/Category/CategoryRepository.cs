using CategoryEntity = Store.Domain.Entities.Category;
using Store.Repositories.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Store.DAL;
using Microsoft.EntityFrameworkCore;

namespace Store.Repositories.Category
{
    public class CategoryRepository : GenericRepository<CategoryEntity>, ICategoryRepository
    {
        private readonly StoreDbContext storeDbContext;

        public CategoryRepository(StoreDbContext storeDbContext) : base(storeDbContext)
        {
            this.storeDbContext = storeDbContext;
        }

        public async Task<CategoryEntity> GetCategoryByName(string name)
        {
            return await storeDbContext.Categories.SingleOrDefaultAsync(x=>x.CategoryName == name);
        }
    }
}
