using CirzzarCurr.Models.Enums;
using System.Drawing;

namespace CirzzarCurr.Models
{
    public abstract class Product
    {
        public virtual decimal Price { get; set; }
        public string Name { get; set; }
        public int? Size { get; set; }
        public Image Image { get; set; }

        public ProductType Type { get; set; }
        public Product()
        {
            Name = string.Empty;
            Size = 0;
        }
        protected Product(decimal price, string name, int? size, Image image, ProductType type)
        {
            Price = price;
            Name = name;
            Size = size;
            Image = image;
            Type = type;
        }
        protected Product(ProductType type) : this()
        {
            Type = type;
        }
    }
}
