using System.Net.Http;
using System.Threading.Tasks;

namespace Kneat.Starwars.Infrastructure.ClientHelper
{
    /// <summary>
    /// Class that wrap the HttpClient and implements an interface.
    /// It can help to implement unit test by implementing Mock<IHttpClient>
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class HttpClientWrap : IHttpClient
    {
        private readonly HttpClient _httpClient;

        public HttpClientWrap()
        {
            _httpClient = new HttpClient();
        }

        public async Task<HttpResponseMessage> GetAsync(string requestUri) => await _httpClient.GetAsync(requestUri);

        public void Dispose() => _httpClient.Dispose();
    }
}