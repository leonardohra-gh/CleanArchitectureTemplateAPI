using SolutionNamePlaceholder.Application.ContaUsuarios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SolutionNamePlaceholder.Application.Interfaces
{
    public interface IContextoUsuario
    {
        ContaUsuarioAtual? RetornarUsuarioAtual();
    }
}
