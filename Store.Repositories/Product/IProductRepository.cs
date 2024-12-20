using ProductEntity = Store.Domain.Entities.Product;
using Store.Repositories.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store.Repositories.Product
{
    public interface IProductRepository : IGenericRepository<ProductEntity>
    {
        Task<List<ProductEntity>> GetProductByCategoryId(int categoryId);
        Task<List<ProductEntity>> GetProductByCategoryAndBrand(int categoryId, int brandId);
    }
}
