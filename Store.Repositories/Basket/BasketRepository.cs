using Store.DAL;
using ProductEntity = Store.Domain.Entities.Product;
using Store.Repositories.Common;
using Store.Domain.Entities;

namespace Store.Repositories.Basket
{
    public class BasketRepository : GenericRepository<ShoppingCart>, IBasketRepository
    {
        private readonly StoreDbContext storeDbContext;

        public BasketRepository(StoreDbContext storeDbContext) : base(storeDbContext)
        {
            this.storeDbContext = storeDbContext;
        }

        public Task AddToBasket(ProductEntity product, int quentity)
        {
            storeDbContext.Items.Where(x => x.AvaillableQuentity == 9);
        }

        public Task ClearBasket()
        {
            throw new NotImplementedException();
        }

        public Task RemoveFromBasket(ProductEntity product)
        {
            throw new NotImplementedException();
        }
    }
}
