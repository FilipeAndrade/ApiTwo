using ApiTwo.Models;

namespace ApiTwo.Services
{
    /// <summary>
    /// 
    /// </summary>
    public interface ITaxService
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="taxCommand"></param>
        /// <returns></returns>
        string TaxCalculate(TaxesCommand taxCommand);
    }
}
