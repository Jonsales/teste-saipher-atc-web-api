using Teste.Saipher.ATC.Domain.Class.Filters;

namespace Teste.Saipher.ATC.Domain.Class
{
    public class PaginateRequest<TFilter>
        where TFilter : BaseFilter
    {
        public int paginaAtual { get; set; } = 1;
        public int quantidadePorPagina { get; set; } = 10;
        public OrderByRequest order { get; set; }
        public TFilter filtro { get; set; } = null;
    }
}
