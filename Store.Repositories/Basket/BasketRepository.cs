using Store.DAL;
using ProductEntity = Store.Domain.Entities.Product;
using BasketEntity = Store.Domain.Entities.Basket;
using Store.Repositories.Common;
using Store.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Store.Repositories.Basket
{
    public class BasketRepository : GenericRepository<BasketEntity>, IBasketRepository
    {
        private readonly StoreDbContext storeDbContext;

        public BasketRepository(StoreDbContext storeDbContext) : base(storeDbContext)
        {
            this.storeDbContext = storeDbContext;
        }

        public async Task AddToBasket(ProductEntity product, int quentity, string userId)
        {
            var userBasket = storeDbContext.Baskets.Where(x=>x.UserId == userId).FirstOrDefault();
            var basketItem = await storeDbContext.BasketItems.Where(x => x.ProductId == product.ProductId).FirstOrDefaultAsync();
            if (basketItem != null)
            {
                basketItem.Quentity += quentity;
            }
            else
            {
                var item = new BasketItem()
                {
                    Quentity = quentity,
                    ProductId = product.ProductId,
                    BasketId = userBasket.BasketId
                };
                userBasket.Status = Domain.Enum.OrederStatus.Processing;
                storeDbContext.Add(item);                
            }
            await storeDbContext.SaveChangesAsync();
        }

        public async Task ClearBasket(string userId)
        {
            var userBasket = storeDbContext.Baskets.Where(x => x.UserId == userId).FirstOrDefault();
            if (userBasket != null)
            {
                userBasket.Status = Domain.Enum.OrederStatus.Reset;
                var items = storeDbContext.BasketItems.Where(x=>x.BasketId == userBasket.BasketId).ToList();
                storeDbContext.RemoveRange(items);
                await storeDbContext.SaveChangesAsync();              
            }
        }

        public async Task RemoveFromBasket(ProductEntity product, string userId)
        {
            var userBasket = storeDbContext.Baskets.Where(x => x.UserId == userId).FirstOrDefault();
            if (userBasket != null)
            {
                var item = storeDbContext.BasketItems.Where(x => x.ProductId == product.ProductId).FirstOrDefault();
                if(item != null)
                {
                    storeDbContext.Remove(item);
                }
                await storeDbContext.SaveChangesAsync();
            }
        }

        public async Task<BasketEntity> GetBasketsWithProducts(string userId)
        {
            return await storeDbContext.Baskets.Include(x=>x.BasketItems).ThenInclude(x=>x.Product).ThenInclude(x=>x.Medias)
                .Where(x=>x.UserId == userId).FirstOrDefaultAsync();
        }

        public async Task<decimal> GetTotalPrice(string userId)
        {
            decimal totalPrice = 0;
            var basket = await storeDbContext.Baskets.Where(x => x.UserId == userId).Include(x => x.BasketItems).ThenInclude(x => x.Product).SingleOrDefaultAsync();
            foreach (var basketItem in basket.BasketItems)
            {
                totalPrice += (basketItem.Quentity) * (basketItem.Product.Price);
            }
            return totalPrice;
        }

        public async Task<int> GetTotalNumberOfProducts(string userId)
        {
            var basketUser = await storeDbContext.Baskets.Where(x => x.UserId == userId).Include(x => x.BasketItems)
                .SingleOrDefaultAsync();

            if (basketUser == null) throw new Exception("User Not Have Basket !!!");

            int itemsCount = 0;
            foreach (var item in basketUser.BasketItems)
            {
                itemsCount += item.Quentity;
            }
            return itemsCount;
        }    
    }
}
