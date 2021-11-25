using System.Collections.Generic;
using System.Threading.Tasks;

namespace Store.Ind.Insfrastructure.Services
{
    public interface IService<T> where T : class
    {
        Task<IEnumerable<T>> ListAll();
        Task<T> GetById(int id);
        Task Create(T categoryDto);
    }
}
