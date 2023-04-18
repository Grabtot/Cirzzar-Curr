

using System.Text.Json.Serialization;

namespace CirzzarCurr.Models
{
    public class Ingredient : IEntity<int>
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public Image? Image { get; set; }
        [JsonIgnore]
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
