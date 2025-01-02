using ProductEntity = Store.Domain.Entities.Product;
using BasketEntity = Store.Domain.Entities.Basket;
using Store.Repositories.Common;
using Store.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store.Repositories.Basket
{
    public interface IBasketRepository : IGenericRepository<BasketEntity>
    {
        Task AddToBasket(ProductEntity product,int quentity, string userId);
        Task RemoveFromBasket(ProductEntity product, string userId);
        Task ClearBasket(string userId);

        // برگردوندن سبد به همراه محصولات ان
        Task<BasketEntity> GetBasketsWithProducts(string userId);

        // مبلغ کل محصولات سبد
        Task<decimal> GetTotalPrice(string userId);

        // برگردوندن تعداد محصولات سبد
        Task<int> GetTotalNumberOfProducts(string userId);
    }
}
