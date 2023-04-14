using CirzzarCurr.Data;
using CirzzarCurr.Models;
using Microsoft.EntityFrameworkCore;

namespace CirzzarCurr.Repositories
{
    public class IngredientsRepository : BaseRepository<Ingredient, int>, IIngredientsRepository
    {
        public IngredientsRepository(ApplicationDbContext context) : base(context) { }
    }
}