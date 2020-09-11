using System;
using System.Net.Http;
using System.Threading.Tasks;
using Kneat.Starwars.Infrastructure.ClientHelper;
using Kneat.Starwars.Infrastructure.Interfaces;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;

namespace Kneat.Starwars.Infrastructure.ClientHelper
{
    /// <summary>
    /// Class used to call the webapi
    /// </summary>
    public class ApiProxy : IApiProxy
    {
        private readonly string _apiUrl;

        private readonly IHttpClient _httpClient;


        /// <summary>
        /// Constructor implements the HttpClient and Configuration interfaces via Dependency Injection
        /// </summary>
        /// <param name="client"></param>
        /// <param name="configuration"></param>
        public ApiProxy(IHttpClient client, IConfiguration configuration)
        {
            _httpClient = client;
            _apiUrl = configuration.GetSection("api").Value;
        }

        /// <summary>
        /// Generic method to get the response of api endpoint
        /// </summary>
        /// <param name="resource"></param>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public async Task<T> GetAsync<T>(string resource)
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

        /// <summary>
        /// Dispose the http object once the operation is finished
        /// </summary>
         public void Dispose() => _httpClient.Dispose();
    }
}