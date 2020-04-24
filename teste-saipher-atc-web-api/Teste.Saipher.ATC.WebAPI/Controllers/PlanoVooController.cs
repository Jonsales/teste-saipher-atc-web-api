using Teste.Saipher.ATC.Application.Interfaces;
using Teste.Saipher.ATC.Application.Models.ViewModels;
using Teste.Saipher.ATC.Domain.Class.Filters;
using Teste.Saipher.ATC.Domain.Interfaces.Services.Helper;
using Teste.Saipher.ATC.WebAPI.Controllers.Base;

namespace Teste.Saipher.ATC.WebAPI.Controllers
{
    public class PlanoVooController : BaseController<IPlanoVooAppService, PlanoVooViewModel, GenericFilter>
    {
        public PlanoVooController(IPlanoVooAppService appService, ILoggerService loggerService) : base(appService, loggerService)
        {
        }
    }
}
