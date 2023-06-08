using CirzzarCurr.Data;
using CirzzarCurr.Models;
using Microsoft.AspNetCore.Identity;

namespace CirzzarCurr.Repositories
{
    class UserRepository : BaseRepository<ApplicationUser, string>, IUserRepository
    {
        public UserManager<ApplicationUser> UserManager { get; private set; }
        private ICartItemRepository _itemRepository;

        public UserRepository(UserManager<ApplicationUser> userManager, ApplicationDbContext context,
            ICartItemRepository itemRepository) : base(context)
        {
            UserManager = userManager;
            _itemRepository = itemRepository;
        }

        public async Task<ApplicationUser> UpdateCartAsync(ApplicationUser user)
        {
            foreach (var cartItem in user.Cart)
            {
                await _itemRepository.AddAsync(cartItem);
            }
            await base.UpdateAsync(user);
            return user;
        }
    }
}


