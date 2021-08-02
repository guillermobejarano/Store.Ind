using Store.Ind.Domain;
using Store.Ind.Domain.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace Store.Ind.Insfrastructure.Data
{
    public class EfRepository : IRepository
    {
        private readonly StoreDbContext _dbContext;

        public EfRepository(StoreDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public T GetById<T>(int id) where T : BaseEntity
        {
            return _dbContext.Set<T>().SingleOrDefault(e => e.Id == id);
        }

        public T GetById<T>(int id, string include) where T : BaseEntity
        {
            return _dbContext.Set<T>()
                .Include(include)
                .SingleOrDefault(e => e.Id == id);
        }

        public List<T> List<T>(ISpecification<T> spec = null) where T : BaseEntity
        {
            var query = _dbContext.Set<T>().AsQueryable();
            if (spec != null)
            {
                query = query.Where(spec.Criteria);
            }
            return query.ToList();
        }

        public T Add<T>(T entity) where T : BaseEntity
        {
            _dbContext.Set<T>().Add(entity);
            _dbContext.SaveChanges();

            return entity;
        }

        public void Delete<T>(T entity) where T : BaseEntity
        {
            _dbContext.Set<T>().Remove(entity);
            _dbContext.SaveChanges();
        }

        public void Update<T>(T entity) where T : BaseEntity
        {
            _dbContext.Entry(entity).State = EntityState.Modified;
            _dbContext.SaveChanges();
        }
    }
}