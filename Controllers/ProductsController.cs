using CirzzarCurr.Models.Products;
using CirzzarCurr.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CirzzarCurr.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly IProductService _productService;

        public ProductsController(IProductService productService)
        {
            _productService = productService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Product>>> Get()
        {
            return Ok(await _productService.GetAllProductsAsync());
        }

        [HttpGet("pizza")]
        public async Task<ActionResult<IEnumerable<Pizza>>> GetPizzas()
        {
            return Ok(await _productService.GetProductsByTypeAsync<Pizza>(Models.Enums.ProductType.Pizza));
        }
        [HttpGet("types")]
        public ActionResult<string[]> GetProductTypes()
        {
            return Ok(_productService.GetProductTypes());
        }

        [HttpGet("pizza/ingredients")]
        public async Task<ActionResult<IEnumerable<Ingredient>>> GetPizzasIngredients()
        {
            return Ok(await _productService.GetAllIngredientsAsync());
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Product>> GetProduct(int id)
        {
            try
            {
                return Ok(await _productService.GetProductByIdAsync(id));
            }
            catch (IndexOutOfRangeException)
            {
                return NotFound();
            }
        }

        [HttpPost]
       // [Authorize]
        public async Task<ActionResult<Product>> AddProduct([FromBody] Product product)
        {
            return Ok(await _productService.AddProductAsync(product));
        }

        [HttpPost("pizza/ingredients")]
        //[Authorize]
        public async Task<ActionResult<Ingredient>> AddIngredient([FromBody] Ingredient ingredient)
        {
            return Ok(await _productService.AddIngredientAsync(ingredient));
        }

        [HttpPut]
       // [Authorize]
        public async Task<ActionResult<Product>> UpdateProduct([FromBody] Product product)
        {
            try
            {
                return Ok(await _productService.UpdateProductAsync(product));
            }
            catch (InvalidOperationException)
            {
                return BadRequest();
            }
        }

        [HttpDelete("{id}")]
      //  [Authorize]
        public async Task<ActionResult> DeleteProduct(int id)
        {
            try
            {
                await _productService.DeleteProductByIdAsync(id);
                return Ok();
            }
            catch (IndexOutOfRangeException)
            {
                return NotFound();
            }
        }
    }
}
