using Teste.Saipher.ATC.Domain.Class.Filters;
using Teste.Saipher.ATC.Domain.Class.Models;
using Teste.Saipher.ATC.Domain.Interfaces.Repositories;
using Teste.Saipher.ATC.Domain.Interfaces.Services;
using Teste.Saipher.ATC.Domain.Services.Base;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Teste.Saipher.ATC.Domain.Services
{
    public class MensagemNotificacaoService : BaseService<IPlanoVooRepository, PlanoVooModel, GenericFilter>, IPlanoVooService
    {
        public MensagemNotificacaoService(IPlanoVooRepository repository) : base(repository)
        {
        }

        public override Task<int> Count(GenericFilter filtro = null)
        {
            throw new NotImplementedException();
        }

        public override Task<List<PlanoVooModel>> Listar(GenericFilter filtro = null, int pagAtual = 1, int qtdItensPorPagina = 10)
        {
            throw new NotImplementedException();
        }

        public override void Validar(PlanoVooModel model)
        {
            this.InformarErro("Falta a validação");
        }
    }
}
