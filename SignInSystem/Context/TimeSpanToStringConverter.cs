using System.Text.Json;
using System.Text.Json.Serialization;
#nullable disable
namespace SignInSystem.Context
{
    public class TimeSpanToStringConverter : JsonConverter<TimeSpan?>
    {
        public override TimeSpan? Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
        {
            var value = reader.GetString();
            if (TimeSpan.TryParse(value, out var result))
            {
                return result;
            }
            return null;
        }

        public override void Write(Utf8JsonWriter writer, TimeSpan? value, JsonSerializerOptions options)
        {
            if (value.HasValue)
            {
                writer.WriteStringValue(value.Value.ToString());
            }
            else
            {
                writer.WriteNullValue();
            }
        }
    }

}
