using System;
using System.Collections.Specialized;
using System.Net.Http;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using TDV.BegetClient.Models;

namespace TDV.BegetClient
{
    public interface IBegetClient
    {
        IBegetDomain Domain { get; }
    }

    public class BegetClient : IBegetClient
    {
        private readonly string _user;
        private readonly string _password;
        private readonly string _apiUrl;
        internal readonly HttpClient _httpClient;

        public BegetClient(string user, string password, string apiUrl = "https://api.beget.com/api/")
        {
            _user = user;
            _password = password;
            _apiUrl = apiUrl;
            _httpClient = new HttpClient();
        }

        public IBegetDomain Domain => new BegetDomain(this);

        internal async Task<string> GetRaw(string url)
        {
            NameValueCollection queryString = System.Web.HttpUtility.ParseQueryString(string.Empty);
            queryString.Add("login", _user);
            queryString.Add("passwd", _password);
            queryString.Add("output_format", "json");
            var resultUrl = _apiUrl + url;
            if (resultUrl.Contains("?"))
            {
                resultUrl += $"&{queryString}";
            }
            else
            {

                resultUrl += $"?{queryString}";
            }
            var resp = await _httpClient.GetAsync(resultUrl);
            resp.EnsureSuccessStatusCode();
            var result = await resp.Content.ReadAsStringAsync();
            return result;
        }

        internal async Task<T> Get<T>(string url) where T : class
        {
            return JsonSerializer.Deserialize<T>(await GetRaw(url), options: JsonSerializerOptions)
                ?? throw new ApplicationException("unable to deserialize");
        }

        internal async Task<T> GetAnswer<T>(string url, bool throwOnError = true) where T : class
        {
            var resp = await Get<BegetResponse<T>>(url);
            if (resp.Status != ResponseStatus.Success && throwOnError)
            {
                throw new ApplicationException($"{resp.ErrorCode}: {resp.ErrorText}");
            }
            return resp.Answer;
        }

        private JsonSerializerOptions JsonSerializerOptions
        {
            get
            {
                var options = new JsonSerializerOptions
                {
                    PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
                    Converters =
                    {
                        new JsonStringEnumConverter(JsonNamingPolicy.CamelCase),
                    }
                };
                return options;
            }
        }
    }
}
