using Teste.Saipher.ATC.Domain.Class.Filters;

namespace Teste.Saipher.ATC.Application.Models.Request
{
    public class PaginateRequest<TFilter>
        where TFilter : BaseFilter
    {
        public int paginaAtual { get; set; } = 1;
        public int? quantidadePorPagina { get; set; } = 0;
        public TFilter filtro { get; set; } = null;
    }
}
