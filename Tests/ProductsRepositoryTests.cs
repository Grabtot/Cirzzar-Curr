using CirzzarCurr.Data;
using CirzzarCurr.Models;
using CirzzarCurr.Models.Enums;
using CirzzarCurr.Repositories;
using CirzzarCurr.Services;
using Duende.IdentityServer.EntityFramework.Options;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using Moq;

namespace Tests
{
    public class ProductsRepositoryTests
    {
        private static DbContextOptions<ApplicationDbContext> GetInMemoryDbContextOptions()
        {
            DbContextOptions<ApplicationDbContext> options = new DbContextOptionsBuilder<ApplicationDbContext>()
                .UseInMemoryDatabase(databaseName: Guid.NewGuid().ToString())
                .Options;

            return options;
        }

        [Fact]
        public async Task AddProduct()
        {
            // Arrange
            DbContextOptions<ApplicationDbContext> options = GetInMemoryDbContextOptions();
            Mock<IImageService> imageServiceMock = new();
            Mock<IOptions<OperationalStoreOptions>> operationalStoreOptionsMock = new();
            operationalStoreOptionsMock.Setup(o => o.Value).Returns(new OperationalStoreOptions());

            Pizza product = GetTestPizza();
            // Act
            using (ApplicationDbContext context = new(options, operationalStoreOptionsMock.Object, imageServiceMock.Object))
            {
                ProductRepository repo = new(context);
                await repo.AddAsync(product);
            }

            // Assert
            using (ApplicationDbContext context = new(options, operationalStoreOptionsMock.Object, imageServiceMock.Object))
            {
                ProductRepository repo = new(context);
                Product productFromDb = await repo.GetByIdAsync(1);
                Assert.NotEmpty(Assert.IsType<Pizza>(productFromDb).Ingredients);
                Assert.NotNull(productFromDb);
                Assert.Equal(1, productFromDb.Id);
                Assert.Equal("Test Product", productFromDb.Name);
                Assert.Equal(ProductType.Pizza, productFromDb.Type);
            }
        }

        [Fact]
        public async Task UpdateProduct()
        {
            //Arrange
            DbContextOptions<ApplicationDbContext> options = GetInMemoryDbContextOptions();
            Mock<IImageService> imageServiceMock = new();
            Mock<IOptions<OperationalStoreOptions>> operationalStoreOptionsMock = new();
            operationalStoreOptionsMock.Setup(o => o.Value).Returns(new OperationalStoreOptions());
            operationalStoreOptionsMock.Setup(o => o.Value).Returns(new OperationalStoreOptions());

            Pizza pizza = GetTestPizza();
            string updatedName = "UpdatedName";

            //Act
            using (ApplicationDbContext context = new(options, operationalStoreOptionsMock.Object, imageServiceMock.Object))
            {
                ProductRepository repository = new(context);
                await repository.AddAsync(pizza);
                pizza.Name = updatedName;
                await repository.UpdateAsync(pizza);
            }

            //Assert
            using (ApplicationDbContext context = new(options, operationalStoreOptionsMock.Object, imageServiceMock.Object))
            {
                ProductRepository repo = new(context);
                Product productFromDb = await repo.GetByIdAsync(1);
                Assert.NotEmpty(Assert.IsType<Pizza>(productFromDb).Ingredients);
                Assert.Equal(1, productFromDb.Id);
                Assert.Equal(updatedName, productFromDb.Name);
            }
        }

        [Fact]
        public async Task DeleteProductTest()
        {
            // Arrange
            DbContextOptions<ApplicationDbContext> options = GetInMemoryDbContextOptions();
            Mock<IImageService> imageServiceMock = new();
            Mock<IOptions<OperationalStoreOptions>> operationalStoreOptionsMock = new();
            operationalStoreOptionsMock.Setup(o => o.Value).Returns(new OperationalStoreOptions());

            Pizza pizza = GetTestPizza();

            // Act
            using (ApplicationDbContext context = new(options, operationalStoreOptionsMock.Object, imageServiceMock.Object))
            {
                ProductRepository repository = new(context);
                await repository.AddAsync(pizza);
                await repository.DeleteByIdAsync(pizza.Id);
            }

            // Assert
            using (ApplicationDbContext context = new(options, operationalStoreOptionsMock.Object, imageServiceMock.Object))
            {
                ProductRepository repo = new(context);
                await Assert.ThrowsAsync<IndexOutOfRangeException>(async () => await repo.GetByIdAsync(pizza.Id));
            }
        }


        private static Pizza GetTestPizza()
        {
            return new()
            {
                Id = 1,
                Name = "Test Product",
                Type = ProductType.Pizza,
                Ingredients = new List<Ingredient> {
                    new() {  Id = 1,  Name = "Test Ingredient 1"},
                    new() { Id = 2, Name="Test Ingredient 2"}
                }
            };

        }
    }
}
