using ProductEntity = Store.Domain.Entities.Product;
using Store.Repositories.Common;
using Store.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store.Repositories.Basket
{
    public interface IBasketRepository : IGenericRepository<ShoppingCart>
    {
        Task AddToBasket(ProductEntity product,int quentity);
        Task RemoveFromBasket(ProductEntity product);
        Task ClearBasket();
    }
}
