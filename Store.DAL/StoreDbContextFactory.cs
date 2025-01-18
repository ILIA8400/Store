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
            string parsan = "Server=192.168.1.37;Database=HardwareStore;User ID=juniorDeveloper; Trust Server Certificate=true; Password=Aa@123456;";
            string man = "Server=.;Database=HardwareStore;User ID=sa; Trust Server Certificate=true; Password=ilia.1384;";
            var optionsBuilder = new DbContextOptionsBuilder<StoreDbContext>();
            optionsBuilder.UseSqlServer(parsan, x =>
            {
                x.CommandTimeout(180);
                x.EnableRetryOnFailure(
                    maxRetryCount: 5, // تعداد تلاش مجدد
                    maxRetryDelay: TimeSpan.FromSeconds(10), // فاصله بین تلاش‌ها
                    errorNumbersToAdd: null); // اعداد خطای سفارشی (می‌توانید خالی بگذارید)
            });

            return new StoreDbContext(optionsBuilder.Options);
        }
    }
}
