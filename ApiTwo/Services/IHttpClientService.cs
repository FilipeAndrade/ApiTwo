using System.Net.Http;
using System.Threading.Tasks;

namespace ApiTwo.Services
{
    /// <summary>
    /// Interface responsavel por manter a instacia do HttpClient
    /// </summary>
    public interface IHttpClientService
    {
        /// <summary>
        /// Obtem a instancia do HttpClient estatica
        /// </summary>
        /// <returns>Retorna um objeto do tipo HttpClient</returns>
        HttpClient CreateClient();

        /// <summary>
        /// Realiza um Get na URL informada
        /// </summary>
        /// <returns>Retorn o resultado da operação</returns>
        Task<HttpResponseMessage> GetAsync(string url);
    }
}
