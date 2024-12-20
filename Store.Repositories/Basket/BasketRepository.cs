using Store.DAL;
using Store.Domain.Entities;
using Store.Repositories.Common;

namespace Store.Repositories.Basket
{
    public class BasketRepository : GenericRepository<ShoppingCart>, IBasketRepository
    {
        private readonly StoreDbContext storeDbContext;

        public BasketRepository(StoreDbContext storeDbContext) : base(storeDbContext)
        {
            this.storeDbContext = storeDbContext;
        }

        public Task AddToBasket(Item item,int number)
        {
            storeDbContext.Items.Add(item);
        }

        public Task ClearBasket()
        {
            throw new NotImplementedException();
        }

        public Task<decimal> GetTotalPrice()
        {
            throw new NotImplementedException();
        }

        public Task RemoveFromBasket(int itemId, int number = 1)
        {
            throw new NotImplementedException();
        }
    }
}
