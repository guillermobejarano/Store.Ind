using Store.Ind.Domain;
using Store.Ind.Domain.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Store.Ind.Insfrastructure.Data
{
    public class EfRepository : IRepository
    {
        private readonly StoreDbContext _dbContext;

        public EfRepository(StoreDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<T> GetById<T>(int id) where T : BaseEntity
        {
            return await _dbContext.Set<T>()
                .SingleOrDefaultAsync(e => e.Id == id);
        }

        public async Task<T> GetById<T>(int id, string include) where T : BaseEntity
        {
            return await _dbContext.Set<T>()
                .Include(include)
                .SingleOrDefaultAsync(e => e.Id == id);
        }

        public async Task<List<T>> List<T>(ISpecification<T> spec = null) where T : BaseEntity
        {
            var query = _dbContext.Set<T>().AsQueryable();
            if (spec != null)
            {
                query = query.Where(spec.Criteria);
            }
            return await query.ToListAsync();
        }

        public async Task<T> Add<T>(T entity) where T : BaseEntity
        {
            await _dbContext.Set<T>().AddAsync(entity);
            await _dbContext.SaveChangesAsync();

            return  entity;
        }

        public async Task Delete<T>(T entity) where T : BaseEntity
        {
            _dbContext.Set<T>().Remove(entity);
            await _dbContext.SaveChangesAsync();
        }

        public async  Task Update<T>(T entity) where T : BaseEntity
        {
            _dbContext.Entry(entity).State = EntityState.Modified;
            await _dbContext.SaveChangesAsync();
        }
    }
}