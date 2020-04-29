using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using Teste.Saipher.ATC.Data.Config;
using Teste.Saipher.ATC.Data.Entities;
using Teste.Saipher.ATC.Data.Repositories.Base;
using Teste.Saipher.ATC.Domain.Class.Filters;
using Teste.Saipher.ATC.Domain.Class.Models;
using Teste.Saipher.ATC.Domain.Interfaces.Repositories;
using Teste.Saipher.ATC.Domain.Interfaces.Services.Helper;

namespace Teste.Saipher.ATC.Data.Repositories
{
    public class PlanoVooRepository : BaseRepository<PlanoVooModel, PlanoVoo, GenericFilter>, IPlanoVooRepository
    {
        public PlanoVooRepository(IMapperService mapper, Context context) : base(mapper, context)
        {
        }

        protected override List<Expression<Func<PlanoVoo, bool>>> Filtrar(GenericFilter filtro)
        {
            var query = new List<Expression<Func<PlanoVoo, bool>>>();
            if (filtro == null )
                return query;

            if (!string.IsNullOrEmpty(filtro.valor))
                query.Add(x => x.MatriculaAeronave == filtro.valor
                    || x.NumeroVoo == filtro.valor
                    || x.Origem == filtro.valor
                    || x.Destino == filtro.valor
                    || x.Id.ToString() == filtro.valor
                    || x.TipoAeronave == filtro.valor);

            return query;
        }
    }
}
