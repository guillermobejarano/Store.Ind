using Store.Ind.Domain.Dtos;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Store.Ind.Insfrastructure.Services
{
    public interface IProductService
    {
        Task<IEnumerable<ProductDto>> ListAllProductsAsync();
        Task<ProductDto> GetProductAsync(int id);
        Task CreateProductAsync(ProductDto product);
    }
}
