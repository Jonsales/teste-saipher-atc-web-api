using Teste.Saipher.ATC.Domain.Class.Filters;
using Teste.Saipher.ATC.Domain.Class.Models.Base;
using Teste.Saipher.ATC.Domain.Interfaces.Filter;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Teste.Saipher.ATC.Domain.Interfaces.Services.Base
{
    public interface IBaseService<TModel, TFilter>
        where TModel : BaseModel
        where TFilter: BaseFilter
    {
        Task<TModel> Criar(TModel model);
        Task<TModel> Atualizar(TModel model);
        Task Deletar(int id);
        Task<List<TModel>> Listar(TFilter filtro = null, int pagAtual = 1, int qtdItensPorPagina = 10);
        Task<TModel> Buscar(int id);
        void Validar(TModel model);
        Task<int> Count(TFilter filtro = null);
    }
}
