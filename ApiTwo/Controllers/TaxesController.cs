using ApiTwo.Models;
using ApiTwo.Services;
using Microsoft.AspNetCore.Mvc;

namespace ApiTwo.Controllers.Taxes
{
    /// <summary>
    /// Controller responsável por calcular os juros
    /// </summary>
    [Route("api/calculajuros")]
    [ApiController]
    public class TaxesController : ControllerBase
    {
        private ITaxService _taxService;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="taxService"></param>
        public TaxesController(ITaxService taxService)
        {
            _taxService = taxService;
        }

        /// <summary>
        /// Método responsável por calcular juros baseado nos parametros recebidos
        /// </summary>
        /// <returns>Retorna um valor sem arredondamento em duas casas decimais</returns>
        [HttpPost]
        public IActionResult CalculaJuros(TaxesCommand command)
        {
            var validator = command.Validate();

            if (!validator.IsValid)
                return BadRequest(validator.Errors);

            return Ok(_taxService.TaxCalculate(command));
        }
    }
}
