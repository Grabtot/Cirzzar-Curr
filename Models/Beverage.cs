using CirzzarCurr.Models.Enums;
using System.Text.Json.Serialization;

namespace CirzzarCurr.Models
{
    public class Beverage : Product
    {
        [JsonConstructor]
        public Beverage(decimal price, string name, int? size, string? image) : base(price, name, size, image, ProductType.Beverage)
        {
        }
        public Beverage() : base(ProductType.Beverage) { }
    }
}
