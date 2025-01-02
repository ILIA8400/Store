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
            //builder.Entity<Invoice>()
            //    .HasOne(i => i.ApplicationUser)
            //    .WithMany(u => u.Invoices)
            //    .HasForeignKey(i => i.UserId)
            //    .OnDelete(DeleteBehavior.SetNull); // یا NoAction

            builder.Entity<Address>()
                .HasOne(a => a.User)
                .WithMany(u => u.Addresses)
                .HasForeignKey(a => a.UserId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.Entity<Invoice>()
                .HasOne(i => i.ApplicationUser)
                .WithMany(u => u.Invoices)
                .HasForeignKey(i => i.ApplicationUserId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.Entity<Invoice>()
                .HasOne(i => i.Address)
                .WithMany(a => a.Invoices)
                .HasForeignKey(i => i.AddressId)
                .OnDelete(DeleteBehavior.Restrict);



            base.OnModelCreating(builder);

        }
    }
}
