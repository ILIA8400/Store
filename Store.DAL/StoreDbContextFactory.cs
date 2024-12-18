using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Store.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.DAL
{
    public class StoreDbContextFactory : IDesignTimeDbContextFactory<StoreDbContext>
    {
        public StoreDbContext CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<StoreDbContext>();
            optionsBuilder.UseSqlServer("Server=192.168.1.37;Database=HardwareStore;User ID=juniorDeveloper; Trust Server Certificate=true; Password=Aa@123456;");

            return new StoreDbContext(optionsBuilder.Options);
        }
    }
}
