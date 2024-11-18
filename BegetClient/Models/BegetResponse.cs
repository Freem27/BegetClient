using System.Text.Json.Serialization;

namespace TDV.BegetClient.Models
{
    public class BegetResponse<T> where T : class
    {
        public ResponseStatus Status { get; set; }
        [JsonPropertyName("error_text")]
        public string ErrorText { get; set; }
        [JsonPropertyName("error_code")]
        public string ErrorCode { get; set; }
        [JsonPropertyName("answer")]
        public T Answer { get; set; }
    }

    public enum ResponseStatus
    {
        Success,
        Error,
    }
}
