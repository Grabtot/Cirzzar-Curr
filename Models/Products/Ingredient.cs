using System.Text.Json.Serialization;

namespace CirzzarCurr.Models.Products
{
    public class Ingredient : IEntity<int>
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string? Image { get; set; }
        [JsonIgnore]
        public List<Pizza> Pizzas { get; set; } = new List<Pizza>();
        public Ingredient()
        {
            Name = string.Empty;
            Image = string.Empty;
        }

        public Ingredient(string name, string? image)
        {
            Name = name;
            Image = image;
        }

        public override string ToString()
        {
            return Name;
        }

        public override bool Equals(object? obj)
        {
            if (obj is Ingredient other)
            {
                return other.Name == Name;
            }
            return base.Equals(obj);
        }
    }
}
