

using System.Text.Json.Serialization;

namespace CirzzarCurr.Models
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
    }
}
