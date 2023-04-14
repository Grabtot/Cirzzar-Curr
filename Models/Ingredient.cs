
namespace CirzzarCurr.Models
{
    public class Ingredient
    {
        public int Id { get; protected set; }
        public string Name { get; set; }
        public Image? Image { get; set; }
        public List<Pizza> Pizzas { get; set; } = new List<Pizza>();
        public Ingredient()
        {
            Name = string.Empty;
            Image = new Image<Rgba32>(1, 1);
        }
        public override string ToString()
        {
            return Name;
        }
    }
}
