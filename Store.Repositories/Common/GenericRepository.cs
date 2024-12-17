using Microsoft.EntityFrameworkCore;
using Store.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store.Repositories.Common
{
    public class GenericRepository<TEntity> : IGenericRepository<TEntity> where TEntity : class
    {
        private readonly StoreDbContext storeDbContext;
        private readonly DbSet<TEntity> _dbSet;

        public GenericRepository(StoreDbContext storeDbContext)
        {
            this.storeDbContext = storeDbContext;
            _dbSet = storeDbContext.Set<TEntity>();
        }

        public void Add(TEntity entity)
        {
            _dbSet.AddAsync(entity);
        }

        public void Delete(TEntity entity)
        {
            _dbSet.Remove(entity);
        }

        public async Task<IEnumerable<TEntity>> GetAll()
        {
            return await _dbSet.ToListAsync();
        }

        public async Task<TEntity> GetById(int id)
        {
            return await _dbSet.FindAsync(id);
        }

        public async Task SaveChange()
        {
            await storeDbContext.SaveChangesAsync();
        }

        public void Update(TEntity entity)
        {
            _dbSet.Update(entity);
        }
    }
}
