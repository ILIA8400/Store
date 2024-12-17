using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Store.Domain.Entities;
using Store.DAL.Identity;

namespace Store.DAL
{
    public class StoreDbContext : IdentityDbContext<ApplicationUser>
    {
        #region Ctor
        public StoreDbContext(DbContextOptions<StoreDbContext> options) : base(options) { }
        #endregion
        #region DbSets
        public DbSet<Product> Products { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Brand> Brands { get; set; }
        public DbSet<ShoppingCart> ShoppingCarts { get; set; }
        public DbSet<Wallet> Wallets { get; set; }
        public DbSet<Transaction> Transactions { get; set; }
        public DbSet<Item> Items { get; set; }
        public DbSet<Invoice> Invoices { get; set; }
        public DbSet<Discount> Discounts { get; set; }
        public DbSet<Address> Addresses { get; set; }
        #endregion
    }
}
