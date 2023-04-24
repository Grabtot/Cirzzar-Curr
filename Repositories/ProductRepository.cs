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
            if (typeof(TProduct) == typeof(Pizza))
            {
                return (await _context.Products
                        .OfType<Pizza>()
                        .Where(prod => prod.Type == type)
                        .Include(prod => prod.Ingredients)
                        .ToListAsync())
                  .Cast<TProduct>()
                  .ToList();


            }

            return (await _context.Products
                                  .Where(prod => prod.Type == type)
                                  .ToListAsync())
                    .OfType<TProduct>();
        }

        public override async Task<Product> GetByIdAsync(int id)
        {
            Product product = await base.GetByIdAsync(id);

            Pizza? pizzaWithIngredients = await _dbSet.OfType<Pizza>()
                                            .Include(p => p.Ingredients)
                                            .SingleOrDefaultAsync(p => p.Id == id);
            return pizzaWithIngredients ?? product;
        }
    }
}
