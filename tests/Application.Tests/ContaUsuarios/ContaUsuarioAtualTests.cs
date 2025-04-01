using Xunit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SolutionNamePlaceholder.Application.ContaUsuarios;
using SolutionNamePlaceholder.Domain.Constants;
using FluentAssertions;

namespace SolutionNamePlaceholder.Application.Tests.ContaUsuarios
{
    public class ContaUsuarioAtualTests
    {
        [Fact()]
        public void PossuiRoleTest_ComMatchingRole_DeveRetornarTrue()
        {
            // Arrange
            var contaUsuarioAtual = new ContaUsuarioAtual("1", "email@email.com", [RolesUsuario.Admin, RolesUsuario.Usuario]);

            // Act
            var possuiRole = contaUsuarioAtual.PossuiRole(RolesUsuario.Admin);

            // Assert
            possuiRole.Should().BeTrue();
        }


        [Fact()]
        public void PossuiRoleTest_SemMatchingRole_DeveRetornarFalse()
        {
            // Arrange
            var contaUsuarioAtual = new ContaUsuarioAtual("1", "email@email.com", [RolesUsuario.Usuario]);

            // Act
            var possuiRole = contaUsuarioAtual.PossuiRole(RolesUsuario.Admin);

            // Assert
            possuiRole.Should().BeFalse();
        }

        [Fact()]
        public void PossuiRoleTest_ComMatchingRoleCase_DeveRetornarFalse()
        {
            // Arrange
            var contaUsuarioAtual = new ContaUsuarioAtual("1", "email@email.com", [RolesUsuario.Admin, RolesUsuario.Usuario]);

            // Act
            var possuiRole = contaUsuarioAtual.PossuiRole(RolesUsuario.Admin.ToLower());

            // Assert
            possuiRole.Should().BeFalse();
        }
    }
}