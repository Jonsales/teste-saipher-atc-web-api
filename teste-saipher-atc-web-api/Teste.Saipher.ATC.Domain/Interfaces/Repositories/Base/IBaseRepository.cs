using Teste.Saipher.ATC.Domain.Class.Models.Base;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Teste.Saipher.ATC.Domain.Interfaces.Repositories.Base
{
    public interface IBaseRepository<TModel>
        where TModel : BaseModel
    {
        Task<List<TModel>> Get(int pagAtual, int qtdItensPorPagina);
        Task<TModel> Get(int id);       
        Task<TModel> Update(TModel model);
        Task Delete(int id);
        Task<TModel> Insert(TModel model);
        Task<int> Count(Expression<Func<TModel, bool>> predicate = null);
        List<TModel> Filtrar(Expression<Func<TModel, bool>> predicate, int pagAtual, int qtdItensPorPagina);
    }
}
