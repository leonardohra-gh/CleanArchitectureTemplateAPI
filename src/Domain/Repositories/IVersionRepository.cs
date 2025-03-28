using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SolutionNamePlaceholder.Domain.Repositories
{
    public interface IVersionRepository
    {
        Task<string> GetLatestVersionAsync();
    }
}
