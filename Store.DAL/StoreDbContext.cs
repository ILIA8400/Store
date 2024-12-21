using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Store.Domain.Entities;
using Store.DAL.Identity;
using System.Reflection.Emit;

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
        public DbSet<Basket> Baskets { get; set; }
        public DbSet<Wallet> Wallets { get; set; }
        public DbSet<Transaction> Transactions { get; set; }
        public DbSet<BasketItem> BasketItems { get; set; }
        public DbSet<Invoice> Invoices { get; set; }
        public DbSet<Discount> Discounts { get; set; }
        public DbSet<Address> Addresses { get; set; }
        public DbSet<InvoiceItem> invoiceItems { get; set; }
        public DbSet<Media> Medias { get; set; }
        #endregion

        protected override void OnModelCreating(ModelBuilder builder)
        {
            //builder.Entity<Category>().HasOne(x=>x.Parent).WithOne().OnDelete(DeleteBehavior.NoAction);
            base.OnModelCreating(builder);
        }
    }
}
