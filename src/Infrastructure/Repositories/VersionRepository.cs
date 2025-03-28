using Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Repositories
{
    public class VersionRepository : IVersionRepository
    {
        public const string CURRENT_VERSION = "0.0.1";

        public async Task<string> GetLatestVersionAsync()
        {
            return await Task.FromResult(CURRENT_VERSION);
        }
    }
}
