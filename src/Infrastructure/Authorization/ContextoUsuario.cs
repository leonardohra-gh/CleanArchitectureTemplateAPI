using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using SolutionNamePlaceholder.Application.ContaUsuarios;
using SolutionNamePlaceholder.Application.Interfaces;

namespace SolutionNamePlaceholder.Infrastructure.Authorization
{
    public class ContextoUsuario(IHttpContextAccessor httpContextAccessor) : IContextoUsuario
    {
        public ContaUsuarioAtual? RetornarUsuarioAtual()
        {
            var usuario = httpContextAccessor?.HttpContext?.User ??
                throw new InvalidOperationException("Contexto de usuário não está presente");

            if (usuario.Identity == null || !usuario.Identity.IsAuthenticated)
                return null;

            var idUsuario = usuario.FindFirst(c => c.Type == ClaimTypes.NameIdentifier)!.Value;
            var email = usuario.FindFirst(c => c.Type == ClaimTypes.Email)!.Value;
            var roles = usuario.Claims.Where(c => c.Type == ClaimTypes.Role)!.Select(c => c.Value);

            return new ContaUsuarioAtual(idUsuario, email, roles);
        }
    }
}