using CirzzarCurr.Models;
using CirzzarCurr.Models.Enums;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CirzzarCurr.Repositories
{
    public interface IProductRepository : IBaseRepository<Product, int>
    {
        Task<IEnumerable<TProduct>> GetByTypeAsync<TProduct>(ProductType type) where TProduct : Product;
    }
}
