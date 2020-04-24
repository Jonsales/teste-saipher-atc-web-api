using Microsoft.Extensions.DependencyInjection;
using Teste.Saipher.ATC.Application.AppServices;
using Teste.Saipher.ATC.Application.Interfaces;
using Teste.Saipher.ATC.CrossCutting;
using Teste.Saipher.ATC.Data.Repositories;
using Teste.Saipher.ATC.Domain.Interfaces.Repositories;
using Teste.Saipher.ATC.Domain.Interfaces.Services;
using Teste.Saipher.ATC.Domain.Interfaces.Services.Helper;
using Teste.Saipher.ATC.Domain.Services;

namespace Teste.Saipher.ATC.IoC
{
    public class BootStrapperConfig
    {
        public static void RegisterServices(IServiceCollection services)
        {
            #region APP SERVICES
            services.AddScoped<IPlanoVooAppService, PlanoVooAppService>();
            #endregion

            #region REPOSITORY
            services.AddScoped<IPlanoVooRepository, PlanoVooRepository>();
            #endregion

            #region SERVICES
            services.AddScoped<IPlanoVooService, MensagemNotificacaoService>();
            services.AddScoped<ILoggerService, LoggerService>();
            #endregion

            #region UTILS
            services.AddScoped<IHelperService, HelperService>();
            services.AddScoped<IMapperService, MapperService>();
            services.AddScoped<IMapperConfig, MapperConfig>();
            #endregion
        }
    }
}
