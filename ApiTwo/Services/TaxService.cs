using ApiTwo.Models;
using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace ApiTwo.Services
{
    /// <summary>
    /// Classe responsavel pelo calculo de juros compostos
    /// </summary>
    public class TaxService : ITaxService
    {
        private static readonly HttpClient _client = new HttpClient();

        /// <summary>
        /// Calcula os juros compostos
        /// </summary>
        /// <param name="taxCommand">Comando com os parametros necessários para calcular os juros compostos</param>
        /// <returns>Retorna o resultado do calculo de juros compostos</returns>
        public string TaxCalculate(TaxesCommand taxCommand)
        {
            var taxaJuros = Task.Run(async () => { return await GetTaxFromApiOne(); }).Result;

            double valorFinal = taxCommand.ValorInicial * Math.Pow((1 + Double.Parse(taxaJuros)), taxCommand.Tempo);

            return string.Format("{0:0.00}", valorFinal);
        }

        /// <summary>
        /// Busca na ApiOne a taxa de juros (Fixo em codigo 0,01)
        /// </summary>
        /// <returns>Retorna a taxa de juros</returns>
        private async Task<string> GetTaxFromApiOne()
        {
            HttpResponseMessage response = await _client.GetAsync("http://localhost:52815/api/taxajuros");

            if (response.IsSuccessStatusCode)
            {
                return await response.Content.ReadAsStringAsync();
            }
            else
            {
                return "0";
            }
        }
    }
}
