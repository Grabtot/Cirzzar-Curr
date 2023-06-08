using CirzzarCurr.Models.Enums;
using CirzzarCurr.Models.Products;

namespace CirzzarCurr.Models.Cart
{
    public class CartItem : IEntity<int>
    {
        public int Id { get; set; }

        public Product Product { get; set; }
        public ProductType ProductType { get; set; }
        public virtual decimal Price => Product.Price * Quantity;
        public int Quantity { get; set; }
        public override bool Equals(object? obj)
        {
            if (obj is CartItem other)
            {
                return other.Product.Name == Product.Name &&
                    other.Product.Price == Price &&
                    other.Product.Size == Product.Size;
            }
            return base.Equals(obj);
        }
    }
}
