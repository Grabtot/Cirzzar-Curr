using CirzzarCurr.Models;
using CirzzarCurr.Services;
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
        [HttpGet("{id}")]
        public async Task<ActionResult<Product>> Get(int id)
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
        public async Task<ActionResult<Product>> Post([FromBody] Product product)
        {
            return Ok(await _productService.AddProductAsync(product));
        }

        [HttpPut]
        public async Task<ActionResult<Product>> Put([FromBody] Product product)
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
        public async Task<ActionResult> Delete(int id)
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
