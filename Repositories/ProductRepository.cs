using CirzzarCurr.Data;
using CirzzarCurr.Models;
using CirzzarCurr.Models.Enums;
using Microsoft.EntityFrameworkCore;

namespace CirzzarCurr.Repositories
{
    public class ProductRepository : BaseRepository<Product, int>, IProductRepository
    {
        public ProductRepository(ApplicationDbContext context) : base(context) { }

        public async Task<IEnumerable<TProduct>> GetByTypeAsync<TProduct>(ProductType type) where TProduct : Product
        {
            return (await _context.Products.Where(prod => prod.Type == type).ToListAsync()).OfType<TProduct>();
        }
    }
}
