using Store.Ind.Domain;
using Store.Ind.Domain.Interfaces;
using Store.Ind.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System.Linq;


namespace Store.Ind.Insfrastructure.Data
{
    public class StoreDbContext : DbContext
    {
        //private readonly IDomainEventDispatcher _dispatcher;

        //public AppDbContext(DbContextOptions options) : base(options)
        //{
        //}

        public StoreDbContext(DbContextOptions<StoreDbContext> options)//, IDomainEventDispatcher dispatcher)
            : base(options)
        {
            //_dispatcher = dispatcher;
        }

        public DbSet<Product> Products { get; set; }

        public DbSet<Variant> Variants { get; set; }

        public DbSet<Category> Categories { get; set; }
        
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            //modelBuilder.ApplyAllConfigurationsFromCurrentAssembly();


            // alternately this is built-in to EF Core 2.2
            //modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        }

        public override int SaveChanges()
        {
            int result = base.SaveChanges();

            // ignore events if no dispatcher provided
            //if (_dispatcher == null) return result;

            // dispatch events only if save was successful
            //var entitiesWithEvents = ChangeTracker.Entries<BaseEntity>()
            //    .Select(e => e.Entity)
            //    .Where(e => e.Events.Any())
            //    .ToArray();

            //foreach (var entity in entitiesWithEvents)
            //{
            //    var events = entity.Events.ToArray();
            //    entity.Events.Clear();
            //    //foreach (var domainEvent in events)
            //    //{
            //    //    _dispatcher.Dispatch(domainEvent);
            //    //}
            //}

            return result;
        }
    }
}