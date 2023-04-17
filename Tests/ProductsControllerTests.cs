using CirzzarCurr.Controllers;
using CirzzarCurr.Models;
using CirzzarCurr.Models.Enums;
using CirzzarCurr.Services;
using Microsoft.AspNetCore.Mvc;
using Moq;


namespace Tests
{
    public class ProductsControllerTests
    {
        [Fact]
        public async Task Get_ListOfProducts()
        {
            Mock<IProductService> mockService = new();
            mockService.Setup(service => service.GetAllProductsAsync())
                .ReturnsAsync(GetTestProducts());
            ProductsController controller = new(mockService.Object);


            ActionResult<IEnumerable<Product>> result = await controller.Get();


            OkObjectResult okResult = Assert.IsType<OkObjectResult>(result.Result);
            IEnumerable<Product> products = Assert.IsAssignableFrom<IEnumerable<Product>>(okResult.Value);
            Assert.Equal(2, products.Count());
        }

        [Fact]
        public async Task Get_ListOfPizza()
        {
            Mock<IProductService> mockService = new();
            mockService.Setup(service => service.GetProductsByTypeAsync<Pizza>(ProductType.Pizza))
                 .ReturnsAsync(GetTestProducts().OfType<Pizza>().ToList());
            ProductsController controller = new(mockService.Object);


            ActionResult<IEnumerable<Pizza>> result = await controller.GetPizzas();

            OkObjectResult okResult = Assert.IsType<OkObjectResult>(result.Result);
            IEnumerable<Pizza> pizzas = Assert.IsAssignableFrom<IEnumerable<Pizza>>(okResult.Value);
            Assert.Equal(2, pizzas.Count());
        }

        [Fact]
        public async Task Get_ListOfIngredients()
        {
            // Arrange
            Mock<IProductService> mockService = new();
            mockService.Setup(service => service.GetAllIngredientsAsync())
                 .ReturnsAsync(GetTestIngredients());
            ProductsController controller = new(mockService.Object);

            // Act
            ActionResult<IEnumerable<Ingredient>> result = await controller.GetPizzasIngredients();

            // Assert
            OkObjectResult okResult = Assert.IsType<OkObjectResult>(result.Result);
            IEnumerable<Ingredient> ingredients = Assert.IsAssignableFrom<IEnumerable<Ingredient>>(okResult.Value);
            Assert.Equal(3, ingredients.Count());
        }

        private static List<Ingredient> GetTestIngredients()
        {
            return new List<Ingredient>
            {
                new Ingredient { Id = 1, Name = "Ham" },
                new Ingredient { Id = 2, Name = "Mushrooms" },
                new Ingredient { Id = 3, Name = "Onions" }
            };
        }

        private static List<Product> GetTestProducts()
        {
            return new List<Product>
            {
                new Pizza { Id = 1, Name = "Pizza 1" },
                new Pizza { Id = 2, Name = "Pizza 2" }
            };
        }
    }


}