using SolutionNamePlaceholder.Application.Services.Versao;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SolutionNamePlaceholder.Application.Interfaces
{
    public interface IVersionService
    {
        VersaoDTO FullVersion { get; }
        string ApiVersion { get; }
        int Major { get; }
        int Minor { get; }
        int Patch { get; }
    }
}
