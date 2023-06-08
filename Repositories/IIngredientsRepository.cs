using CirzzarCurr.Models.Products;

namespace CirzzarCurr.Repositories
{
    public interface IIngredientsRepository : IBaseRepository<Ingredient, int>
    {
        Task<Pizza> GetPizzaWithDbIngredientsAsync(Pizza pizza);
    }
}