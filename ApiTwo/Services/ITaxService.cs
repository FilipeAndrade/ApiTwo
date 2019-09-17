using ApiTwo.Models;

namespace ApiTwo.Services
{
    /// <summary>
    /// Interface responsavel pelo calculo de juros compostos
    /// </summary>
    public interface ITaxService
    {
        /// <summary>
        /// Calcula os juros compostos
        /// </summary>
        /// <param name="taxCommand">Comando com os parametros necessários para calcular os juros compostos</param>
        /// <returns>Retorna o resultado do calculo de juros compostos</returns>
        string TaxCalculate(TaxesCommand taxCommand);
    }
}
