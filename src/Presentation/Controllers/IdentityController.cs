using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SolutionNamePlaceholder.Application.ContaUsuarios.Commands.AdicionarRoleUsuario;
using SolutionNamePlaceholder.Application.ContaUsuarios.Commands.RetirarRoleUsuario;
using SolutionNamePlaceholder.Domain.Constants;

namespace SolutionNamePlaceholder.Presentation.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class IdentityController(IMediator mediator) : ControllerBase
    {
        /// <summary>
        /// Atribui uma role a um usuário
        /// </summary>
        /// <param name="comando"></param>
        /// <returns>Sem retorno</returns>
        /// <remarks>
        /// Para usar esse endpoint, é necessário uma conta de administrador
        /// Exemplo de request:
        ///
        ///     POST /api/identity/roleUsuario
        ///     {
        ///         "emailUsuario" = "usuario@usuario",
        ///         "nomeRole" = "Admin"
        ///     }
        ///
        /// </remarks>
        /// <response code="204">Atribuição realizada, sem retorno</response>
        /// <response code="404">Caso a role ou um usuário com o emails passado não sejam encontrados no banco de dados</response>
        [HttpPost("roleUsuario")]
        [Authorize(Roles = RolesUsuario.Admin)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> AssignUserRole(AdicionarRoleUsuarioCommand comando)
        {
            await mediator.Send(comando);
            return NoContent();
        }

        /// <summary>
        /// Retira uma role de um usuário
        /// </summary>
        /// <param name="comando"></param>
        /// <returns>Sem retorno</returns>
        /// <remarks>
        /// Para usar esse endpoint, é necessário uma conta de administrador
        /// Exemplo de request:
        ///
        ///     DELETE /api/identity/roleUsuario
        ///     {
        ///         "EmailUsuario" = "usuario@usuario",
        ///         "Role" = "Admin"
        ///     }
        ///
        /// </remarks>
        /// <response code="204">Role retirada, sem retorno</response>
        /// <response code="404">Caso a role ou um usuário com o emails passado não sejam encontrados no banco de dados</response>
        [HttpDelete("roleUsuario")]
        [Authorize(Roles = RolesUsuario.Admin)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> UnassignUserRole(RetirarRoleUsuarioCommand comando)
        {
            await mediator.Send(comando);
            return NoContent();
        }
    }
}
