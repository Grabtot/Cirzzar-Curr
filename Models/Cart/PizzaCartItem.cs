using CirzzarCurr.Models.Enums;
using CirzzarCurr.Models.Products;

namespace CirzzarCurr.Models.Cart
{
    public class PizzaCartItem : CartItem
    {
        public PizzaSize SelectedSize { get; set; }
        public override decimal Price
        {
            get
            {
                Pizza pizza = Product as Pizza ?? throw new ArgumentException($"{Product.Name} isn't a pizza");
                decimal price = Product.MinimalPrice;
                switch (SelectedSize)
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

                decimal priceWithExtraIngredients = price + 15 * pizza.Ingredients.Count - 2;
                return pizza.Ingredients.Count > 2 ? priceWithExtraIngredients : price;
            }
        }
        public override bool Equals(object? obj)
        {
            if (obj is PizzaCartItem other)
            {
                if (!base.Equals(obj) || other.SelectedSize != SelectedSize)
                    return false;

                if (Product is not Pizza pizza ||
                    other.Product is not Pizza otherPizza ||
                    pizza.Ingredients.Count != otherPizza.Ingredients.Count)
                    return false;

                for (int i = 0; i < pizza.Ingredients.Count; i++)
                {
                    if (!pizza.Ingredients[i].Equals(otherPizza.Ingredients[i]))
                        return false;
                }

                return true;
            }

            return false;
        }

    }
}
