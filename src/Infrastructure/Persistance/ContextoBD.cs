using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using SolutionNamePlaceholder.Infrastructure.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SolutionNamePlaceholder.Infrastructure.Persistance
{
    public class ContextoBD(DbContextOptions<ContextoBD> opcoes) : IdentityDbContext<ContaUsuario>(opcoes)
    {
        internal DbSet<ContaUsuario> ContasUsuarios { get; set; }
    }
}
