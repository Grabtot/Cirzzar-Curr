using CirzzarCurr.Models.Enums;
using System.Drawing;

namespace CirzzarCurr.Models
{
    public class Pizza : Product
    {
        public Pizza(decimal price, string name, int? size, Image image, PizzaSize pizzaSize) : base(price, name, size, image, ProductType.Pizza)
        {
            PizzaSize = pizzaSize;
        }

        public override decimal Price { get; set; }
        public PizzaSize PizzaSize { get; set; }
    }
}
