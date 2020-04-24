using Teste.Saipher.ATC.Application.Interfaces;
using Teste.Saipher.ATC.Application.Models.ViewModels;
using Teste.Saipher.ATC.Application.AppServices.Base;
using Teste.Saipher.ATC.Domain.Class.Filters;
using Teste.Saipher.ATC.Domain.Class.Models;
using Teste.Saipher.ATC.Domain.Interfaces.Services;
using Teste.Saipher.ATC.Domain.Interfaces.Services.Helper;

namespace Teste.Saipher.ATC.Application.AppServices
{
    public class PlanoVooAppService : BaseAppService<IPlanoVooService, PlanoVooViewModel, PlanoVooModel, GenericFilter>, IPlanoVooAppService
    {
        public PlanoVooAppService(IPlanoVooService service, IMapperService mapper, IHelperService helper) : base(service, mapper, helper)
        {
        }

        internal override string Name { get; set; } = "Mensagem Notificação";
    }
}
