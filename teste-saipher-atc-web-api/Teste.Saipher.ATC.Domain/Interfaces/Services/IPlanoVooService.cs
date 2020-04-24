using Teste.Saipher.ATC.Domain.Class.Filters;
using Teste.Saipher.ATC.Domain.Class.Models;
using Teste.Saipher.ATC.Domain.Interfaces.Services.Base;

namespace Teste.Saipher.ATC.Domain.Interfaces.Services
{
    public interface IPlanoVooService : IBaseService<PlanoVooModel, GenericFilter>
    {
    }
}
