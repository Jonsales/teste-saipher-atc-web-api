using AutoMapper;
using Teste.Saipher.ATC.Application.Models.ViewModels;
using Teste.Saipher.ATC.Data.Entities;
using Teste.Saipher.ATC.Domain.Class.Models;

namespace Teste.Saipher.ATC.CrossCutting
{
    public class MappingDomainToRepository : Profile
    {
        public MappingDomainToRepository()
        {
            CreateMap<PlanoVoo, PlanoVooModel>()
                .ReverseMap();
        }
    }

    public class MappingApplicationToDomain : Profile
    {
        public MappingApplicationToDomain()
        {
            CreateMap<PlanoVooViewModel, PlanoVooModel>()
                .ForMember(a => a.Id, map => map.MapFrom(x=>x.id))
                .ForMember(a => a.DataAlteracao, map => map.MapFrom(x => x.dataAlteracao))
                .ForMember(a => a.DataCadastro, map => map.MapFrom(x => x.dataCadastro))
                .ForMember(a => a.NumeroVoo, map => map.MapFrom(x => x.numeroVoo))
                .ForMember(a => a.DataHoraVoo, map => map.MapFrom(x => x.dataHoraVoo))
                .ForMember(a => a.Destino, map => map.MapFrom(x => x.destino))
                .ForMember(a => a.MatriculaAeronave, map => map.MapFrom(x => x.matriculaAeronave))
                .ForMember(a => a.Origem, map => map.MapFrom(x => x.origem))
                .ForMember(a => a.TipoAeronave, map => map.MapFrom(x => x.tipoAeronave))
                .ReverseMap();
        }
    }
}
