using CirzzarCurr.Models;
using CirzzarCurr.Models.Cart;
using CirzzarCurr.Repositories;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace CirzzarCurr.Services
{
    public class UserService : IUserService
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly IUserRepository _userRepository;

        public UserService(UserManager<ApplicationUser> userManager, IUserRepository userRepository)
        {
            _userManager = userManager;
            _userRepository = userRepository;
        }

        public async Task<ApplicationUser> AddProductToCartAsync(CartItem product, string userId)
        {
            ApplicationUser user = await _userManager.Users.Include(u => u.Cart)
                .FirstOrDefaultAsync(u => u.Id == userId)
                ?? throw new UnauthorizedAccessException();

            user.Cart ??= new();
            CartItem? existingProduct = user.Cart.FirstOrDefault(prod => prod.Equals(product));
            if (existingProduct is not null)
            {
                existingProduct.Quantity += product.Quantity;
            }
            else
            {
                user.Cart.Add(product);
            }

            await _userRepository.UpdateCartAsync(user);
            return user;
        }
    }
}
