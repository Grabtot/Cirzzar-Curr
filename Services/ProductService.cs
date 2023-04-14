using CirzzarCurr.Models;
using CirzzarCurr.Models.Enums;
using CirzzarCurr.Repositories;

namespace CirzzarCurr.Services
{
    public class ProductService : IProductService
    {
        private readonly IProductRepository _productRepository;

        public ProductService(IProductRepository productRepository)
        {
            _productRepository = productRepository;
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
            return await _productRepository.AddAsync(product);
        }

        public async Task<Product> UpdateProductAsync(Product product)
        {
            return await _productRepository.UpdateAsync(product);
        }

        public async Task DeleteProductByIdAsync(int id)
        {
            await _productRepository.DeleteByIdAsync(id);
        }
    }

}
