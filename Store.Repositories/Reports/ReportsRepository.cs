using Store.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store.Repositories.Reports
{
    public class ReportsRepository : IReportsRepository
    {
        private readonly StoreDbContext storeDbContext;

        public ReportsRepository(StoreDbContext storeDbContext)
        {
            this.storeDbContext = storeDbContext;
        }

        
    }
}
