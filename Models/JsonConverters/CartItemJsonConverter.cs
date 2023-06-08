using CirzzarCurr.Models.Cart;
using CirzzarCurr.Models.Products;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace CirzzarCurr.Models.JsonConverters
{
    public class CartItemJsonConverter : JsonConverter<CartItem>
    {
        public override CartItem? Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
        {
            using JsonDocument jsonDocument = JsonDocument.ParseValue(ref reader);

            JsonElement jsonObject = jsonDocument.RootElement;

            if (!jsonObject.TryGetProperty("product", out JsonElement jsonProduct))
            {
                throw new InvalidOperationException("Cart item must contain a product");
            }
            Product product = JsonSerializer.Deserialize<Product>(jsonProduct.GetRawText(), options);

            if (product is Pizza)
            {
                return JsonSerializer.Deserialize<PizzaCartItem>
               (jsonObject.ToString(), options);
            }
            return JsonSerializer.Deserialize<CartItem>(jsonObject.ToString(), options);
        }

        public override void Write(Utf8JsonWriter writer, CartItem value, JsonSerializerOptions options)
        {
            JsonSerializer.Serialize(writer, (object)value, options);
        }
    }
}
