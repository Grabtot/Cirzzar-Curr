using CirzzarCurr.Models;
using CirzzarCurr.Models.Enums;

namespace CirzzarCurr.Services
{
    public interface IProductService
    {
        Task<Product> AddProductAsync(Product product);
        Task<Ingredient> AddIngredientAsync(Ingredient ingredient);
        Task DeleteProductByIdAsync(int id);
        Task<IEnumerable<Ingredient>> GetAllIngredientsAsync();
        Task<IEnumerable<Product>> GetAllProductsAsync();
        Task<Product> GetProductByIdAsync(int id);
        Task<IEnumerable<TProduct>> GetProductsByTypeAsync<TProduct>(ProductType type) where TProduct : Product;
        Task<Product> UpdateProductAsync(Product product);
    }
}