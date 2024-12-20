using Store.Domain.Entities;
using Store.Repositories.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store.Repositories.Basket
{
    public interface IBasketRepository : IGenericRepository<ShoppingCart>
    {
        Task AddToBasket(Item item,int number);
        Task RemoveFromBasket(int itemId,int number = 1);
        Task<decimal> GetTotalPrice(); 
        Task ClearBasket();
    }
}
