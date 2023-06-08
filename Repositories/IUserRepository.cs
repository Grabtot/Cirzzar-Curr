using CirzzarCurr.Models;
using Microsoft.AspNetCore.Identity;

namespace CirzzarCurr.Repositories
{
    public interface IUserRepository : IBaseRepository<ApplicationUser, string>
    {
        UserManager<ApplicationUser> UserManager { get; }
        Task<ApplicationUser> UpdateCartAsync(ApplicationUser user);
    }
}


