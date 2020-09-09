using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace Kneat.Starwars.Infrastructure.ClientHelper
{
    public interface IHttpClient : IDisposable
    {
         Task<HttpResponseMessage> GetAsync(string requestUri);
    }
}