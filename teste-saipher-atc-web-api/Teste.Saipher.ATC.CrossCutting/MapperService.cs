using AutoMapper;
using Teste.Saipher.ATC.Domain.Interfaces.Services.Helper;

namespace Teste.Saipher.ATC.CrossCutting
{
    public class MapperService : IMapperService
    {
        private readonly IMapperConfig _mapperConfig;

        public MapperService(IMapperConfig mapperConfig)
        {
            _mapperConfig = mapperConfig;
        }
        public TResult Map<TResult, TSource>(TSource convert)
        {
            var config = (MapperConfiguration)_mapperConfig.ConfigureMapper();
            var mapper = new Mapper(config);
            var dto = mapper.Map<TSource, TResult>(convert);
            return dto;
        }
    }
}
