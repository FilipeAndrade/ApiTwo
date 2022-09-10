using ApiTwo.Models;
using ApiTwo.Services;
using Microsoft.AspNetCore.Mvc;

namespace ApiTwo.Controllers
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
        /// Construtor do controller
        /// </summary>
        /// <param name="taxService">Interface injetada da classe que calcula os juros compostos</param>
        public TaxesController(ITaxService taxService)
        {
            _taxService = taxService;
        }

        /// <summary>
        /// Método responsável por calcular juros baseado nos parametros recebidos
        /// </summary>
        /// <returns>Retorna um valor sem arredondamento em duas casas decimais</returns>
        [HttpPost]
        [ProducesResponseType(200)]
        [ProducesResponseType(400)]
        public IActionResult TaxCalculate(TaxesCommand command)
        {
            var validator = command.Validate();

            if (!validator.IsValid)
                return BadRequest(validator.Errors);

            return Ok(_taxService.TaxCalculate(command));
        }
    }
}
