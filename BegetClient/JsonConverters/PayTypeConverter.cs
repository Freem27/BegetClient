using System;
using System.Text.Json;
using System.Text.Json.Serialization;
using TDV.BegetClient.Enums;

namespace TDV.BegetClient
{
    internal class PayTypeConverter : JsonConverter<PayType>
    {
        public override bool CanConvert(Type typeToConvert)
        {
            return base.CanConvert(typeToConvert); 
        }
        public override PayType Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
        {
            switch (reader.TokenType)
            {
                case JsonTokenType.String:
                    var str = reader.GetString();
                    if (str == "money")
                    {
                        return PayType.Money;
                    }
                    if (str == "bonus_domain ")
                    {
                        return PayType.BonusDomain;
                    }
                    if (str == null)
                    {
                        return PayType.UnableToPay;
                    }
                    throw new ApplicationException("Unexpected value: " + str);
                case JsonTokenType.False:
                    return PayType.UnableToPay;
                default:
                    throw new NotSupportedException();

            }
        }

        public override void Write(Utf8JsonWriter writer, PayType value, JsonSerializerOptions options)
        {
            throw new NotImplementedException();
        }
    }
}
