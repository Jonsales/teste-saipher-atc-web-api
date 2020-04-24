using AutoMapper;
using Teste.Saipher.ATC.CrossCutting;
using Teste.Saipher.ATC.Domain.Interfaces.Services.Helper;

namespace Teste.Saipher.ATC.IoC
{
    public class MapperConfig : IMapperConfig
    {
        //public static Mapper mapper { get; set; }
        public static MapperConfiguration configuration { get; set; }
        public object ConfigureMapper()
        {
            return new MapperConfiguration(cfg =>
            {
                cfg.AddProfile<MappingDomainToRepository>();
                cfg.AddProfile<MappingApplicationToDomain>();
            });
            //return configuration;
            // only during development, validate your mappings; remove it before release
            //configuration.AssertConfigurationIsValid();
        }
    }
}
