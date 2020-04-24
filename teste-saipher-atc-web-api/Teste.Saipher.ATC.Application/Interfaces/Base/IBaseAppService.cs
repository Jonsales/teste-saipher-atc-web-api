using Teste.Saipher.ATC.Application.Models.Request;
using Teste.Saipher.ATC.Application.Models.Result;
using Teste.Saipher.ATC.Application.Models.ViewModels.Base;
using Teste.Saipher.ATC.Domain.Class.Filters;
using Teste.Saipher.ATC.Domain.Interfaces.Filter;
using System.Threading.Tasks;

namespace Teste.Saipher.ATC.Application.Interfaces.Base
{
    public interface IBaseAppService<TViewModel, TFilter>
        where TViewModel : BaseViewModel
        where TFilter : BaseFilter
    {
        Task<BaseRequestResulData<TViewModel>> Criar(TViewModel model);
        Task<BaseRequestResulData<TViewModel>> Atualizar(TViewModel model);
        Task<BaseRequestResulData<TViewModel>> Buscar(int id);
        Task<BaseRequestResulData<TViewModel>> Deletar(int id);
        Task<BaseRequestResultList<TViewModel>> Listar(PaginateRequest<TFilter> filtroRequest);
    }
}
