using CategoryEntity = Store.Domain.Entities.Category;
using Store.Repositories.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Store.DAL;

namespace Store.Repositories.Category
{
    public class CategoryRepository : GenericRepository<CategoryEntity>, ICategoryRepository
    {
        public CategoryRepository(StoreDbContext storeDbContext) : base(storeDbContext) { }       
    }
}
