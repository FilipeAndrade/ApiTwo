using ApiTwo.Models;
using System;
using System.Globalization;
using System.Net.Http;
using System.Threading.Tasks;

namespace ApiTwo.Services
{
    /// <summary>
    /// Classe responsavel pelo calculo de juros compostos
    /// </summary>
    public class TaxService : ITaxService
    {
        private readonly CultureInfo _culture = CultureInfo.GetCultureInfo("pt-BR");

        /// <summary>
        /// Instancia injetada da interface do HttpClient
        /// </summary>
        private readonly IHttpClientService _client;

        /// <summary>
        /// Construtor onde receberá a injeção da interface do HttpClient
        /// </summary>
        /// <param name="client">Instancia do HttpClient</param>
        public TaxService(IHttpClientService client)
        {
            _client = client;
        }

        /// <summary>
        /// Calcula os juros compostos
        /// </summary>
        /// <param name="taxCommand">Comando com os parametros necessários para calcular os juros compostos</param>
        /// <returns>Retorna o resultado do calculo de juros compostos</returns>
        public string TaxCalculate(TaxesCommand taxCommand)
        {
            var taxaJuros = Task.Run(async () => { return await GetTaxFromApiOne(); }).Result;

            if (taxaJuros == null)
                return "Não foi possível calcular os juros compostos";

            double valorFinal = taxCommand.ValorInicial * Math.Pow((1 + Double.Parse(taxaJuros, _culture)), taxCommand.Tempo);

            return string.Format(_culture, "{0:0.00}", valorFinal);
        }

        /// <summary>
        /// Busca na ApiOne a taxa de juros (Fixo em codigo 0,01)
        /// </summary>
        /// <returns>Retorna a taxa de juros</returns>
        private async Task<string> GetTaxFromApiOne()
        {
            _client?.CreateClient();

            HttpResponseMessage response = await _client?.GetAsync("http://192.168.15.11:4000/api/taxajuros");

            if (response != null && response.IsSuccessStatusCode)
            {
                return await response.Content.ReadAsStringAsync();
            }
            else
            {
                return null;
            }
        }
    }
}
