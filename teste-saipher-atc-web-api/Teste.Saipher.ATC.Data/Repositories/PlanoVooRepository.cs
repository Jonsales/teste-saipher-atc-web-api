using Teste.Saipher.ATC.Data.Config;
using Teste.Saipher.ATC.Data.Entities;
using Teste.Saipher.ATC.Data.Repositories.Base;
using Teste.Saipher.ATC.Domain.Class.Models;
using Teste.Saipher.ATC.Domain.Interfaces.Repositories;
using Teste.Saipher.ATC.Domain.Interfaces.Services.Helper;

namespace Teste.Saipher.ATC.Data.Repositories
{
    public class PlanoVooRepository : BaseRepository<PlanoVooModel, PlanoVoo>, IPlanoVooRepository
    {
        public PlanoVooRepository(IMapperService mapper, Context context) : base(mapper, context)
        {
        }
    }
}
