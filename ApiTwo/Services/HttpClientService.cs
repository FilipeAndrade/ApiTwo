using System.Net.Http;
using System.Threading.Tasks;

namespace ApiTwo.Services
{
    /// <summary>
    /// Classe responsavel por manter a instacia do HttpClient
    /// </summary>
    public class HttpClientService : IHttpClientService
    {
        private static readonly HttpClient _client = new HttpClient();

        /// <summary>
        /// Obtem a instancia do HttpClient estatica
        /// </summary>
        /// <returns>Retorna um objeto do tipo HttpClient</returns>
        public HttpClient CreateClient() => _client;

        /// <summary>
        /// Realiza um Get na URL informada
        /// </summary>
        /// <returns>Retorn o resultado da operação</returns>
        public async Task<HttpResponseMessage> GetAsync(string url)
        {
            return await _client.GetAsync(url);
        }
    }
}
