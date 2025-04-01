using Xunit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Security.Claims;
using SolutionNamePlaceholder.Domain.Constants;
using Microsoft.AspNetCore.Http;
using Moq;
using SolutionNamePlaceholder.Infrastructure.Authorization;
using FluentAssertions;

namespace SolutionNamePlaceholder.Infrastructure.Tests.Authorization
{
    public class ContextoUsuarioTests
    {
        private static readonly List<string> todasRoles = [RolesUsuario.Admin, RolesUsuario.Usuario];
        private static ClaimsPrincipal ClaimsUsuarioAutenticado(
            string name = "1",
            string email = "teste@teste.com",
            List<string> roles = null!
        )
        {
            roles ??= todasRoles;
            var claims = new List<Claim>
            {
                new(ClaimTypes.NameIdentifier, name),
                new(ClaimTypes.Email, email)
            };
            claims.AddRange(roles.Select(role => new Claim(ClaimTypes.Role, role)));

            return new ClaimsPrincipal(new ClaimsIdentity(claims, "Test"));
        }

        private static IHttpContextAccessor CriarContextAccessor(ClaimsPrincipal claimsPrincipalUsuario)
        {
            var httpContextAccessorMock = new Mock<IHttpContextAccessor>();
            httpContextAccessorMock
                .Setup(h => h.HttpContext)
                .Returns(new DefaultHttpContext() { User = claimsPrincipalUsuario });

            return httpContextAccessorMock.Object;
        }

        [Fact()]
        public void RetornarUsuarioAtualTest_ComUsuarioAutenticado_DeveRetornarContaUsuarioAtual()
        {
            // Arrange
            var nome = "Abc";
            var email = "abc@teste.com";
            var claimsPrincipalUsuarioAutenticado = ClaimsUsuarioAutenticado(nome, email, todasRoles);
            var contextAccessorUsuarioAutenticado = CriarContextAccessor(claimsPrincipalUsuarioAutenticado);
            var contextoUsuarioAutenticado = new ContextoUsuario(contextAccessorUsuarioAutenticado);

            // Act
            var usuarioAtual = contextoUsuarioAutenticado.RetornarUsuarioAtual();

            // Assert
            usuarioAtual.Should().NotBeNull();
            usuarioAtual.Id.Should().Be(nome);
            usuarioAtual.Email.Should().Be(email);
            usuarioAtual.Roles.Should().BeEquivalentTo(todasRoles);
        }

        [Fact()]
        public void RetornarUsuarioAtualTest_ComUsuarioNull_DeveRetornarNull()
        {
            // Arrange
            var contextAccessorUsuarioNull = CriarContextAccessor(null!);
            var contextoUsuarioNull = new ContextoUsuario(contextAccessorUsuarioNull);

            // Act
            var usuarioAtualNull = contextoUsuarioNull.RetornarUsuarioAtual();

            // Assert
            usuarioAtualNull.Should().BeNull();
        }
    }
}