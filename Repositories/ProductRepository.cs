using CirzzarCurr.Data;
using CirzzarCurr.Models;
using CirzzarCurr.Models.Enums;
using Microsoft.EntityFrameworkCore;

namespace CirzzarCurr.Repositories
{
    public class ProductRepository : IProductRepository
    {
        private ApplicationDbContext _context;

        public ProductRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<Product> AddAsync(Product product)
        {
            await _context.Products.AddAsync(product);
            await _context.SaveChangesAsync();
            return product;
        }

        public async Task DeleteByIdAsync(int id)
        {
            var product = await GetByIdAsync(id);
            _context.Products.Remove(product);
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<Product>> GetAllAsync()
        {
            return await _context.Products.ToListAsync();
        }

        public async Task<Product> GetByIdAsync(int id)
        {
            return await _context.Products.FindAsync(id)
                ?? throw new IndexOutOfRangeException("Wrong index");
        }

        public async Task<IEnumerable<TProduct>> GetByTypeAsync<TProduct>(ProductType type) where TProduct : Product
        {
            return (await _context.Products.Where(prod => prod.Type == type).ToListAsync()).OfType<TProduct>();
        }

        public async Task<Product> UpdateAsync(Product product)
        {
            product = _context.Products.Update(product).Entity;
            await _context.SaveChangesAsync();
            return product;
        }
    }
}
