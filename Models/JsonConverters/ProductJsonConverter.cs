using CirzzarCurr.Models.Enums;
using CirzzarCurr.Models.Products;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace CirzzarCurr.Models.JsonConverters
{
    public class ProductJsonConverter : JsonConverter<Product>
    {


        public override Product Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
        {
            using JsonDocument jsonDocument = JsonDocument.ParseValue(ref reader);

            JsonElement jsonObject = jsonDocument.RootElement;

            if (!jsonObject.TryGetProperty("type", out JsonElement typeProperty))
            {
                throw new InvalidOperationException("Product must contain a type");
            }

            ProductType productType = JsonSerializer.Deserialize<ProductType>(typeProperty.GetRawText(), options);

            return productType switch
            {
                ProductType.Pizza => JsonSerializer.Deserialize<Pizza>(jsonObject.ToString(), options) ?? throw new JsonException("Failed to deserialize Pizza"),
                ProductType.Dessert => JsonSerializer.Deserialize<Dessert>(jsonObject.ToString(), options) ?? throw new JsonException("Failed to deserialize Dessert"),
                ProductType.Beverage => JsonSerializer.Deserialize<Beverage>(jsonObject.ToString(), options) ?? throw new JsonException("Failed to deserialize Beverage"),
                _ => throw new NotSupportedException($"Unknown product type: {productType}"),
            };
        }

        public override void Write(Utf8JsonWriter writer, Product value, JsonSerializerOptions options)
        {

            JsonSerializer.Serialize(writer, (object)value, options);
        }
    }

}
