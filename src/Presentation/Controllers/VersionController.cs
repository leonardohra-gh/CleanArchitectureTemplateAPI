using Microsoft.AspNetCore.Mvc;
using SolutionNamePlaceholder.Application.Interfaces;
using SolutionNamePlaceholder.Application.Services.Versao;

namespace SolutionNamePlaceholder.Presentation.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VersionController(IVersionService service) : ControllerBase
    {
        /// <summary>
        /// Retorna a versão atual da API
        /// </summary>
        /// <response code="200">Retorna o valor atual da versão</response>
        [HttpGet]
        [ProducesResponseType(typeof(VersaoDTO), 200)]
        public IActionResult GetVersion()
        {
            var versao = service.FullVersion;
            return Ok(versao);
        }
    }
}
