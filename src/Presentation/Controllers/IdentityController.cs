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
        [HttpPost("roleUsuario")]
        [Authorize(Roles = RolesUsuario.Admin)]
        public async Task<IActionResult> AssignUserRole(AdicionarRoleUsuarioCommand comando)
        {
            await mediator.Send(comando);
            return NoContent();
        }

        [HttpDelete("roleUsuario")]
        [Authorize(Roles = RolesUsuario.Admin)]
        public async Task<IActionResult> UnassignUserRole(RetirarRoleUsuarioCommand comando)
        {
            await mediator.Send(comando);
            return NoContent();
        }
    }
}
