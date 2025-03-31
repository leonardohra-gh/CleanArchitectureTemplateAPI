using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SolutionNamePlaceholder.Infrastructure.Seeders
{
    public class ExecutorSeed(IEnumerable<ISeeder> seeders)
    {
        public async Task ExecutarSeeders()
        {
            foreach (var seeder in seeders.OrderBy(s => s.Ordem)) await seeder.Seed();
        }
    }
}
