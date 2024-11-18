using System;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace TDV.BegetClient.JsonConverters
{
    internal class JsonBoolConverter : JsonConverter<bool>
    {
        public override bool CanConvert(Type typeToConvert)
        {
            return base.CanConvert(typeToConvert);
            //return typeToConvert == typeof(string);
        }
        public override bool Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
        {
            switch (reader.TokenType)
            {
                case JsonTokenType.String:
                    var str = reader.GetString();
                    return str == "1";
                case JsonTokenType.Number:
                    return reader.GetInt32() == 1;
                case JsonTokenType.True:
                    return true;
                case JsonTokenType.False:
                    return false;
                default:
                    throw new NotSupportedException();

            }
        }

        public override void Write(Utf8JsonWriter writer, bool value, JsonSerializerOptions options)
        {
            writer.WriteStringValue(value ? "1" : "0");
        }
    }
}
