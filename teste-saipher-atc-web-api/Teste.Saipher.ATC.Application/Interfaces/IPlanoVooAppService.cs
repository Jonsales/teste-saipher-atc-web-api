using Teste.Saipher.ATC.Application.Interfaces.Base;
using Teste.Saipher.ATC.Application.Models.ViewModels;
using Teste.Saipher.ATC.Domain.Class.Filters;

namespace Teste.Saipher.ATC.Application.Interfaces
{
    public interface IPlanoVooAppService : IBaseAppService<PlanoVooViewModel, GenericFilter>
    {
    }
}
