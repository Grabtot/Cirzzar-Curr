using CirzzarCurr.Models.Enums;
using System.Text.Json.Serialization;


namespace CirzzarCurr.Models
{
    public class Pizza : Product
    {

        [JsonConstructor]
        public Pizza(decimal price, string name, int? size, Image image) : base(price, name, size, image, ProductType.Pizza)
        {
            PizzaSize = PizzaSize.Small;

        }
        public Pizza() : base(ProductType.Pizza) { }

        public override decimal Price
        {
            get
            {
                decimal price = MinimalPrice;
                switch (PizzaSize)
                {
                    case PizzaSize.Small:
                        break;
                    case PizzaSize.Medium:
                        price *= 1.5M;
                        break;
                    case PizzaSize.Large:
                        price *= 2M;
                        break;
                    case PizzaSize.ExtraLarge:
                        price *= 2.1M;
                        break;
                }

                decimal priceWithExtraIngredients = price + 15 * Ingredients.Count - 2;
                return Ingredients.Count > 2 ? priceWithExtraIngredients : price;
            }
        }
        public PizzaSize PizzaSize { get; set; }
        public List<Ingredient> Ingredients { get; set; } = new();
    }
}
