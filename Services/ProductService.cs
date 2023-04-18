using CirzzarCurr.Models;
using CirzzarCurr.Models.Enums;
using CirzzarCurr.Repositories;
using Microsoft.EntityFrameworkCore;

namespace CirzzarCurr.Services
{
    public class ProductService : IProductService
    {
        private readonly IProductRepository _productRepository;
        private readonly IIngredientsRepository _ingredientsRepository;
        public ProductService(IProductRepository productRepository, IIngredientsRepository ingredientsRepository)
        {
            _productRepository = productRepository;
            _ingredientsRepository = ingredientsRepository;
        }

        public async Task<IEnumerable<Product>> GetAllProductsAsync()
        {
            return await _productRepository.GetAllAsync();
        }

        public async Task<Product> GetProductByIdAsync(int id)
        {
            return await _productRepository.GetByIdAsync(id);
        }

        public async Task<IEnumerable<TProduct>> GetProductsByTypeAsync<TProduct>(ProductType type) where TProduct : Product
        {
            return await _productRepository.GetByTypeAsync<TProduct>(type);
        }

        public async Task<Product> AddProductAsync(Product product)
        {
            Product newProduct = product is Pizza pizza ? await _ingredientsRepository.GetPizzaWithDbIngredientsAsync(pizza) : product;
            return await _productRepository.AddAsync(newProduct);
        }


        public async Task<Product> UpdateProductAsync(Product product)
        {
            return await _productRepository.UpdateAsync(product);
        }

        public async Task DeleteProductByIdAsync(int id)
        {
            await _productRepository.DeleteByIdAsync(id);
        }

        public async Task<Ingredient> AddIngredientAsync(Ingredient ingredient)
        {
            return await _ingredientsRepository.AddAsync(ingredient);
        }

        public async Task<IEnumerable<Ingredient>> GetAllIngredientsAsync()
        {
            return await _ingredientsRepository.GetAllAsync();
        }
    }

}
