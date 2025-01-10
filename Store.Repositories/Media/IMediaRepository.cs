using Store.Repositories.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store.Repositories.Media
{
    public interface IMediaRepository : IGenericRepository<Domain.Entities.Media>
    {
        Task<int> GetIdByMediaName(string path);
        Task<Domain.Entities.Media> GetByProductId(int id);
    }
}
