using Teste.Saipher.ATC.Domain.Class.Filters;
using Teste.Saipher.ATC.Domain.Class.Models.Base;
using Teste.Saipher.ATC.Domain.Interfaces.Repositories.Base;
using Teste.Saipher.ATC.Domain.Interfaces.Services.Base;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Teste.Saipher.ATC.Domain.Services.Base
{
    public abstract class BaseService<TRepository, TModel, TFilter> : IBaseService<TModel, TFilter>
        where TRepository : IBaseRepository<TModel>
        where TModel : BaseModel
        where TFilter : BaseFilter
    {
        protected readonly TRepository _repository;
        public BaseService(TRepository repository)
        {
            _repository = repository;
        }

        public async Task<TModel> Atualizar(TModel model)
        {
            this.Validar(model);
            return await _repository.Update(model);
        }
        public async Task<TModel> Buscar(int id) =>
            await _repository.Get(id);       
        public async Task<TModel> Criar(TModel model)
        {
            this.Validar(model);
            return await _repository.Insert(model);
        }
        public async Task Deletar(int id) =>
            await _repository.Delete(id);
        public async Task<List<TModel>> Listar(int pagAtual, int qtdItensPorPagina) =>
            await _repository.Get(pagAtual, qtdItensPorPagina);
        public abstract Task<List<TModel>> Listar(TFilter filtro = null, int pagAtual = 1, int qtdItensPorPagina = 10);
        public abstract void Validar(TModel model);
        public abstract Task<int> Count(TFilter filtro = null);
        protected void InformarErro(string erro) =>
            throw new Exception(erro, new Exception("ERROR"));
    }
}
