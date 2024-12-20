using BrandEntity = Store.Domain.Entities.Brand;
using Store.Repositories.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store.Repositories.Brand
{
    public interface IBrandRepository : IGenericRepository<BrandEntity>
    {
        Task<List<BrandEntity>> GetBrandsByCategoryId(int categoryId);
    }
}
