using CirzzarCurr.Models;
using CirzzarCurr.Models.Enums;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CirzzarCurr.Repositories
{
    public interface IProductRepository
    {
        Task<IEnumerable<Product>> GetAllAsync();
        Task<IEnumerable<TProduct>> GetByTypeAsync<TProduct>(ProductType type) where TProduct : Product;
        Task<Product> GetByIdAsync(int id);
        Task<Product> AddAsync(Product product);
        Task<Product> UpdateAsync(Product product);
        Task DeleteByIdAsync(int id);
    }
}
