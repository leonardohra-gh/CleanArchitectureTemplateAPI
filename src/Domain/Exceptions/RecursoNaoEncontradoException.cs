using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Security.AccessControl;
using System.Text;
using System.Threading.Tasks;

namespace SolutionNamePlaceholder.Domain.Exceptions
{
    public class RecursoNaoEncontradoException(string resourceType, string resourceIdentifier) : 
        CustomException($"{resourceType} com id {resourceIdentifier} não existe", HttpStatusCode.NotFound)
    {
    }
}
