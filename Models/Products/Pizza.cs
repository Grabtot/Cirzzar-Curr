using CirzzarCurr.Models.Enums;
using System.Text.Json.Serialization;

namespace CirzzarCurr.Models.Products
{
    public class Pizza : Product
    {

        [JsonConstructor]
        public Pizza(decimal price, string name, int size, string image) : base(price, name, size, image, ProductType.Pizza)
        { }
        public Pizza() : base(ProductType.Pizza) { }
        public List<Ingredient> Ingredients { get; set; } = new();

    }
}
