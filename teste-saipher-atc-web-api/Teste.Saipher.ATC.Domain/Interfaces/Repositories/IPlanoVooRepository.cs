using System.Threading.Tasks;
using Teste.Saipher.ATC.Domain.Class.Filters;
using Teste.Saipher.ATC.Domain.Class.Models;
using Teste.Saipher.ATC.Domain.Interfaces.Repositories.Base;

namespace Teste.Saipher.ATC.Domain.Interfaces.Repositories
{
    public interface IPlanoVooRepository: IBaseRepository<PlanoVooModel, GenericFilter>
    {
        Task<bool> VerficarNumeroVoo(string numeroVoo);
    }
}
