using System.Text.Json;
using System.Text.Json.Serialization;

namespace CirzzarCurr.Models.JsonConverters
{
    public class EnumJsonConverter<TEnum> : JsonConverter<TEnum> where TEnum : struct, Enum
    {
        public override TEnum Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
        {
            var enumValueStr = reader.GetString();
            return Enum.TryParse(enumValueStr, out TEnum enumValue) ? enumValue : throw new InvalidOperationException(enumValueStr);
        }

        public override void Write(Utf8JsonWriter writer, TEnum value, JsonSerializerOptions options)
        {
            writer.WriteStringValue(Enum.GetName(value));
        }
    }

}
