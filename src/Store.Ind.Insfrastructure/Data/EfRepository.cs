using Store.Ind.Domain;
using Store.Ind.Domain.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Linq.Expressions;
using System;

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
            // fetch a Queryable that includes all expression-based includes
            var queryableResultWithIncludes = spec.Includes
                .Aggregate(_dbContext.Set<T>().AsQueryable(),
                    (current, include) => current.Include(include));

            // modify the IQueryable to include any string-based include statements
            var secondaryResult = spec.IncludeStrings
                .Aggregate(queryableResultWithIncludes,
                    (current, include) => current.Include(include));

            // return the result of the query using the specification's criteria expression
            if (spec.Criteria != null)
            {
                secondaryResult = secondaryResult
                            .Where(spec.Criteria);
            }

            return await secondaryResult
                            .ToListAsync();
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