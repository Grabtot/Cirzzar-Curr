using CirzzarCurr.Models;
using CirzzarCurr.Models.Enums;
using CirzzarCurr.Repositories;

namespace CirzzarCurr.Services
{
    public class ProductService : IProductService
    {
        private readonly IProductRepository _productRepository;
        private readonly IIngredientsRepository _ingredientsRepository;
        private readonly IImageService _imageService;
        public ProductService(IProductRepository productRepository, IIngredientsRepository ingredientsRepository, IImageService imageService)
        {
            _productRepository = productRepository;
            _ingredientsRepository = ingredientsRepository;
            _imageService = imageService;
        }

        public async Task<IEnumerable<Product>> GetAllProductsAsync()
        {
            List<Product> products = (List<Product>)await _productRepository.GetAllAsync();
            for (int i = 0; i < products.Count; i++)
            {
                products[i].Image = _imageService.GetEncodedByPath(products[i].Image);
            }
            return products;
        }

        public async Task<Product> GetProductByIdAsync(int id)
        {
            Product product = await _productRepository.GetByIdAsync(id);
            product.Image = _imageService.GetEncodedByPath(product.Image);
            return product;
        }

        public async Task<IEnumerable<TProduct>> GetProductsByTypeAsync<TProduct>(ProductType type) where TProduct : Product
        {
            List<TProduct> products = (List<TProduct>)await _productRepository.GetByTypeAsync<TProduct>(type);
            for (int i = 0; i < products.Count; i++)
            {
                products[i].Image = _imageService.GetEncodedByPath(products[i].Image);
            }
            return products;
        }

        public async Task<Product> AddProductAsync(Product product)
        {
            Product newProduct = product is Pizza pizza ? await _ingredientsRepository.GetPizzaWithDbIngredientsAsync(pizza) : product;

            product.Image = _imageService.Save(product.Image, Enum.GetName(product.Type), product.Name);
            return await _productRepository.AddAsync(newProduct);
        }


        public async Task<Product> UpdateProductAsync(Product product)
        {
            product.Image = _imageService.Save(product.Image, Enum.GetName(product.Type), product.Name);
            return await _productRepository.UpdateAsync(product);
        }

        public async Task DeleteProductByIdAsync(int id)
        {
            Product product = await _productRepository.GetByIdAsync(id);
            _imageService.Delete(Enum.GetName(product.Type), product.Name);
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

        public string[] GetProductTypes()
        {
            return Enum.GetNames<ProductType>();
        }
    }

}
