using CirzzarCurr.Models;
using CirzzarCurr.Models.Cart;
using CirzzarCurr.Services;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace CirzzarCurr.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;
        private readonly UserManager<ApplicationUser> _userManager;

        public UserController(IUserService userService, UserManager<ApplicationUser> userManager = null)
        {
            _userService = userService;
            _userManager = userManager;
        }
        [HttpPut]
        public async Task<ActionResult> AddProductToUserCart([FromBody] CartItem product)
        {
            string userId = User.FindFirst(System.Security.Claims.ClaimTypes.NameIdentifier)?.Value;
            await _userService.AddProductToCartAsync(product, userId);
            return Ok();
        }
    }
}
