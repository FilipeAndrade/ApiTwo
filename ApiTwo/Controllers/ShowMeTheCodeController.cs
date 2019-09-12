﻿using Microsoft.AspNetCore.Mvc;

namespace ApiTwo.Controllers
{
    /// <summary>
    /// Controller responsável pelo método que retorna a url do Github que contém o código fonte
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    public class ShowMeTheCodeController : ControllerBase
    {
        /// <summary>
        /// Método responsável por retornar a url do Github que contém o código fonte da Api atual
        /// </summary>
        /// <returns>Retorna uma string com a url do Github que contém o código fonte</returns>
        [HttpGet]
        public ActionResult<string> Get()
        {
            return new string("https://github.com/FilipeAndrade/ApiTwo");
        }
    }
}
