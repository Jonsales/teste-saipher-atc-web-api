using Teste.Saipher.ATC.Domain.Class.Filters;
using Teste.Saipher.ATC.Domain.Class.Models.Base;
using System.Collections.Generic;
using System.Threading.Tasks;
using Teste.Saipher.ATC.Domain.Class;

namespace Teste.Saipher.ATC.Domain.Interfaces.Services.Base
{
    public interface IBaseService<TModel, TFilter>
        where TModel : BaseModel
        where TFilter: BaseFilter
    {
        Task<TModel> Criar(TModel model);
        Task<TModel> Atualizar(TModel model);
        Task Deletar(int id);
        Task<List<TModel>> Listar(PaginateRequest<TFilter> paginate);
        Task<TModel> Buscar(int id);
        Task Validar(TModel model);
        Task<int> Count(TFilter filtro = null);
    }
}
