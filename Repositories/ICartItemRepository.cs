using CirzzarCurr.Data;
using CirzzarCurr.Models.Cart;

namespace CirzzarCurr.Repositories
{
    public interface ICartItemRepository : IBaseRepository<CartItem, int>
    {
    }

    public class CartItemRepository : BaseRepository<CartItem, int>, ICartItemRepository
    {
        public CartItemRepository(ApplicationDbContext context) : base(context)
        {
        }
    }
}
