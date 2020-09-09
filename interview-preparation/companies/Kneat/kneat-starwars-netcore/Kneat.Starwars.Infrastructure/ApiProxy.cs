using System;
using System.Net.Http;
using System.Threading.Tasks;
using Kneat.Starwars.Infrastructure.ClientHelper;
using Newtonsoft.Json;

namespace Kneat.Starwars.Infrastructure
{
    public class ApiProxy
    {
        private readonly string _apiUrl;

        private readonly IHttpClient _httpClient;

        public ApiProxy(IHttpClient client, string apiUrl)
        {
            _httpClient = client;
            _apiUrl = apiUrl;
        }

        public async Task<T> Get<T>(string resource)
        {
            var responseHttp = await _httpClient.GetAsync($"{_apiUrl}/{resource}");

            if(responseHttp.IsSuccessStatusCode)
            {
                var jsonString = responseHttp.Content.ReadAsStringAsync();
                jsonString.Wait();

                T obj = JsonConvert.DeserializeObject<T>(jsonString.Result);

                return obj;
            }

            return default(T);
        }
    }
}