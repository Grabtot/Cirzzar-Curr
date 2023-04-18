using CirzzarCurr.Data;
using CirzzarCurr.Models;
using Microsoft.EntityFrameworkCore;

namespace CirzzarCurr.Repositories
{
    public class IngredientsRepository : BaseRepository<Ingredient, int>, IIngredientsRepository
    {
        public IngredientsRepository(ApplicationDbContext context) : base(context) { }

        public async Task<Pizza> GetPizzaWithDbIngredientsAsync(Pizza pizza)
        {
            List<Ingredient> ingredients = await _dbSet.Where(i => pizza.Ingredients.
            Select(ing => ing.Id).Contains(i.Id)).ToListAsync();

            pizza.Ingredients = ingredients;
            return pizza;
        }
    }
}