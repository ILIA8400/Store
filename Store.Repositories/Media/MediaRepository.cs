using Microsoft.EntityFrameworkCore;
using Store.DAL;
using Store.Repositories.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store.Repositories.Media
{
    public class MediaRepository : GenericRepository<Domain.Entities.Media>, IMediaRepository
    {
        private readonly StoreDbContext storeDbContext;

        public MediaRepository(StoreDbContext storeDbContext) : base(storeDbContext)
        {
            this.storeDbContext = storeDbContext;
        }

        public async Task<Domain.Entities.Media> GetByProductId(int id)
        {
            return await storeDbContext.Medias.SingleOrDefaultAsync(x=>x.ProductId == id);
        }

        public async Task<int> GetIdByMediaName(string path)
        {
            return (await storeDbContext.Medias.SingleOrDefaultAsync(x => x.Path == path)).MediaId;
        }
    }
}
