using CirzzarCurr.Models.Enums;
using System.Text.Json.Serialization;

namespace CirzzarCurr.Models.Products
{
    public class Dessert : Product
    {
        [JsonConstructor]
        public Dessert(decimal price, string name, int size, string? image) : base(price, name, size, image, ProductType.Dessert)
        {
        }

        public Dessert() : base(ProductType.Dessert) { }
    }
}
