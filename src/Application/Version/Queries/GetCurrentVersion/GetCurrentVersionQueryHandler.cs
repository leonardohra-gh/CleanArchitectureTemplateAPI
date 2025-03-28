using SolutionNamePlaceholder.Domain.Repositories;
using MediatR;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SolutionNamePlaceholder.Application.Version.Queries.GetCurrentVersion
{
    public class GetCurrentVersionQueryHandler(
        ILogger<GetCurrentVersionQueryHandler> logger,
        IVersionRepository repository
    ) : IRequestHandler<GetCurrentVersionQuery, string>
    {
        public async Task<string> Handle(GetCurrentVersionQuery request, CancellationToken cancellationToken)
        {
            logger.LogInformation("Consultando versão atual da aplicação");
            return await repository.GetLatestVersionAsync();
        }
    }
}
