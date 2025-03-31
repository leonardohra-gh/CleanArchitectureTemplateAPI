using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SolutionNamePlaceholder.Application.Common
{
    public class PagedResult<T>
    {
        public IEnumerable<T> Itens { get; set; } = default!;
        public int TotalPaginas { get; set; }
        public int QuantidadeTotalItens { get; set; }
        public int ItensDe { get; set; }
        public int ItensAte { get; set; }

        public PagedResult(IEnumerable<T> itens, int quantidadeTotal, int tamanhoPagina, int numeroPagina)
        {
            Itens = itens;
            QuantidadeTotalItens = quantidadeTotal;
            TotalPaginas = (int)Math.Ceiling(((double)quantidadeTotal)/tamanhoPagina);
            ItensDe = tamanhoPagina * (numeroPagina - 1) + 1;
            ItensAte = ItensDe + (tamanhoPagina - 1);
        }
    }
}
