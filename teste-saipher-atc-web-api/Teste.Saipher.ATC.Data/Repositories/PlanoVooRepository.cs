using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
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

        public async Task<bool> VerficarNumeroVoo(string numeroVoo)
        {
            try
            {
                return _context.Set<PlanoVoo>().Any(x => x.NumeroVoo.ToLower() == numeroVoo.ToLower());
            }
            catch (Exception ex)
            {
                throw new Exception($@"Erro ao Verificar Nu=úmero de Voo. {ex.Message}");
            }
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
