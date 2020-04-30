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

        public async override Task Validar(PlanoVooModel model)
        {
            if(model == null)
                this.InformarErro("Preencha os campos para prosseguir");
            if (string.IsNullOrEmpty(model.NumeroVoo))
                this.InformarErro("Preencha o Número do Voo");
            if (string.IsNullOrEmpty(model.MatriculaAeronave))
                this.InformarErro("Preencha a Matrícula da Aeronave");
            if (model.DataHoraVoo == null)
                this.InformarErro("Preencha a Data e Hora do Voo");
            if (string.IsNullOrEmpty(model.TipoAeronave))
                this.InformarErro("Preencha o Tipo da Aeronave");
            if (string.IsNullOrEmpty(model.Origem))
                this.InformarErro("Preencha a Origem do Voo");
            if (string.IsNullOrEmpty(model.Destino))
                this.InformarErro("Preencha a Destino do Voo");

            if (model.NumeroVoo.Length != 7)
                this.InformarErro("O Número do Voo deve conter 7 caracteres");
            if (model.MatriculaAeronave.Length != 7)
                this.InformarErro("A Matrícula da Aeronave deve conter 7 caracteres");
            if (model.TipoAeronave.Length != 4)
                this.InformarErro("O Tipo da Aeronave deve conter 7 caracteres");
            if (model.Origem.Length != 4)
                this.InformarErro("A Origem deve conter 7 caracteres");
            if (model.Destino.Length != 4)
                this.InformarErro("O Destino deve conter 7 caracteres");

            if(model.Id == 0)
            {
                var existeNumeroVoo = await _repository.VerficarNumeroVoo(model.NumeroVoo);
                if (existeNumeroVoo)
                    this.InformarErro("O Número do Voo que foi informado, já existe. Informe outro Número do Voo para continuar");
            }

            model.NumeroVoo = model.NumeroVoo.ToUpper();
            model.MatriculaAeronave = model.MatriculaAeronave.ToUpper();
            model.TipoAeronave = model.TipoAeronave.ToUpper();
            model.Origem = model.Origem.ToUpper();
            model.Destino = model.Destino.ToUpper();
        }
    }
}
