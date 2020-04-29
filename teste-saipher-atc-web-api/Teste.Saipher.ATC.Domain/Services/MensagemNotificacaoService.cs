using Teste.Saipher.ATC.Domain.Class.Filters;
using Teste.Saipher.ATC.Domain.Class.Models;
using Teste.Saipher.ATC.Domain.Interfaces.Repositories;
using Teste.Saipher.ATC.Domain.Interfaces.Services;
using Teste.Saipher.ATC.Domain.Services.Base;
using System.Threading.Tasks;

namespace Teste.Saipher.ATC.Domain.Services
{
    public class MensagemNotificacaoService : BaseService<IPlanoVooRepository, PlanoVooModel, GenericFilter>, IPlanoVooService
    {
        public MensagemNotificacaoService(IPlanoVooRepository repository) : base(repository)
        {
        }

        public async override Task<int> Count(GenericFilter filtro = null) =>
            await _repository.Count();

        public override void Validar(PlanoVooModel model)
        {
            this.InformarErro("Falta a validação");
        }
    }
}
