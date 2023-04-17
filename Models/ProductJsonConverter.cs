using CirzzarCurr.Models.Enums;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace CirzzarCurr.Models
{
    public class ProductJsonConverter : JsonConverter<Product>
    {
        public override Product Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
        {
            using (var jsonDocument = JsonDocument.ParseValue(ref reader))
            {
                var jsonObject = jsonDocument.RootElement;
                var productType = jsonObject.GetProperty("type").Deserialize<ProductType>();

                switch (productType)
                {
                    case ProductType.Pizza:
                        return JsonSerializer.Deserialize<Pizza>(jsonObject.ToString(), options);
                    // Добавьте здесь обработку других типов продуктов, если необходимо
                    default:
                        throw new NotSupportedException($"Неизвестный тип продукта: {productType}");
                }
            }
        }

        public override void Write(Utf8JsonWriter writer, Product value, JsonSerializerOptions options)
        {
            JsonSerializer.Serialize(writer, (object)value, options);
        }
    }
}
