using CirzzarCurr.Models.Enums;
using System.Text.Json.Serialization;

namespace CirzzarCurr.Models.Products
{
    public abstract class Product : IEntity<int>
    {
        private decimal _minimalPrice;
        public decimal MinimalPrice
        {
            get => _minimalPrice; protected set
            {
                if (value < 0)
                {
                    throw new ArgumentOutOfRangeException(nameof(value));
                }
                _minimalPrice = value;
            }
        }
        public virtual decimal Price => _minimalPrice;
        public int Id { get; set; }
        public string Name { get; set; }
        public int Size { get; set; }
        public string? Image { get; set; }
        public ProductType Type { get; set; }

        public Product()
        {
            Name = string.Empty;
            Size = 0;
            Image = string.Empty;
        }

        [JsonConstructor]
        public Product(decimal price, string name, int size, string? image, ProductType type)
        {
            MinimalPrice = price;
            Name = name;
            Size = size;
            Image = image;
            Type = type;
        }

        public Product(ProductType type) : this()

        {
            Type = type;
        }
        public override string ToString()
        {
            return Name;
        }
    }
}
