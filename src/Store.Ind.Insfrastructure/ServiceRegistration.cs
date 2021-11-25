using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using Store.Ind.Domain.Interfaces;
using Store.Ind.Insfrastructure.Configuration;
using Store.Ind.Insfrastructure.Data;
using Store.Ind.Insfrastructure.Services;

namespace Store.Ind.Insfrastructure
{
    public static class ServiceRegistration
    {
        public static void AddInfrastructureServices(this IServiceCollection services, IConfiguration configuration)
        {
            #region Configuration            
            //services.Configure<IOptions<ContextConfiguration>>(configuration.gets.GetSection("ConnectionStrings"));
            #endregion

            #region Services for entity framework                     
            services.AddDbContext<StoreDbContext>(
                options => options.UseSqlServer("name=ConnectionStrings:DefaultConnection"));
            #endregion            

            #region Repositories           

            //services.AddDbContext<StoreDbContext>(opts =>
            //     opts.UseInMemoryDatabase("userDB"));
            services.AddScoped<StoreDbContext>();
            services.AddScoped<IRepository, EfRepository>();
            services.AddScoped<IProductService, ProductService>();
            services.AddScoped<ICategoryService, CategoryService>();

            #endregion
        }
    }
}
