using CategoryEntity = Store.Domain.Entities.Category;
using Store.Repositories.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store.Repositories.Category
{
    public interface ICategoryRepository : IGenericRepository<CategoryEntity>
    {
    }
}
