using CirzzarCurr.Models;
using CirzzarCurr.Models.Cart;

namespace CirzzarCurr.Services
{
    public interface IUserService
    {
        Task<ApplicationUser> AddProductToCartAsync(CartItem product, string userId);
    }
}
