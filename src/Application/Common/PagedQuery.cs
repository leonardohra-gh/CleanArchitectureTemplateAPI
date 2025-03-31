using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SolutionNamePlaceholder.Application.Common
{
    public abstract class PagedQuery<TResponse>
        : IRequest<PagedResult<TResponse>>
    {
        public string? FiltroBusca { get; set; }
        public int NumeroPagina { get; set; } = 1;
        public int TamanhoPagina { get; set; } = 10;
        public string? OrdernarPor { get; set; }
        public SortDirection DirecaoOrdenacao { get; set; } = SortDirection.Ascending;
    }
}
