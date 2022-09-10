using Microsoft.AspNetCore.Mvc;

namespace ApiTwo.Controllers
{
    /// <summary>
    /// Controller responsável pelo método que retorna a url do Github que contém o código fonte
    /// </summary>
    [Route("api/showmethecode")]
    [ApiController]
    public class SourceCodeController : ControllerBase
    {
        /// <summary>
        /// Método responsável por retornar a url do Github que contém o código fonte da Api atual
        /// </summary>
        /// <returns>Retorna uma string com a url do Github que contém o código fonte</returns>
        [HttpGet]
        [ProducesResponseType(200)]
        public IActionResult Get()
        {
            return Ok("https://github.com/FilipeAndrade/ApiTwo");
        }
    }
}
