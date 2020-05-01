using Microsoft.EntityFrameworkCore;
using Teste.Saipher.ATC.Data.Config;
using Teste.Saipher.ATC.Data.Entities.Base;
using Teste.Saipher.ATC.Domain.Class.Models.Base;
using Teste.Saipher.ATC.Domain.Interfaces.Repositories;
using Teste.Saipher.ATC.Domain.Interfaces.Repositories.Base;
using Teste.Saipher.ATC.Domain.Interfaces.Services.Helper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Teste.Saipher.ATC.Domain.Class;
using Teste.Saipher.ATC.Domain.Class.Filters;

namespace Teste.Saipher.ATC.Data.Repositories.Base
{
    public abstract class BaseRepository<TModel, TEntity, TFilter> : IBaseRepository<TModel, TFilter>
        where TModel : BaseModel
        where TEntity : BaseEntity
        where TFilter : BaseFilter
    {
        protected readonly IMapperService _mapper;
        protected readonly Context _context;

        public BaseRepository(IMapperService mapper, Context context)
        {
            _mapper = mapper;
            _context = context;
        }
        protected TModel _result { get; set; }
        protected List<TModel> _resultList { get; set; }
       
        public async Task Delete(int id)
        {
            try
            {
                var entity = _mapper.Map<TEntity, TModel>(await Get(id));
                _context.Set<TEntity>().Remove(entity);
                _context.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new Exception($@"Erro ao deletar. {ex.Message}");
            }
        }

        public List<TModel> Filtrar(Expression<Func<TModel, bool>> predicate, int pagAtual, int qtdItensPorPagina)
        {
            try
            {
                _resultList = _context.Set<TModel>().Where(predicate).OrderBy(c => c.Id).Skip((pagAtual - 1) * qtdItensPorPagina).Take(qtdItensPorPagina).ToList();
                return _resultList;
            }catch(Exception ex)
            {
                throw new Exception($@"Erro ao filtar. {ex.Message}");
            }
        }

        public async Task<List<TModel>> Get(PaginateRequest<TFilter> paginate)
        {
            try
            {
                var entities = QueryList(_context.Set<TEntity>(), paginate)
                       .Skip((paginate.paginaAtual - 1) * paginate.quantidadePorPagina)
                       .Take(paginate.quantidadePorPagina).ToList();
                _resultList = _mapper.Map<List<TModel>, List<TEntity>>(entities);
                return _resultList;
            }
            catch (Exception ex)
            {
                throw new Exception($@"Erro ao Listar. {ex.Message}");
            }
        }

        public async Task<TModel> Get(int id)
        {
            try
            {
                _context.ChangeTracker.LazyLoadingEnabled = true;
                _result = _mapper.Map<TModel, TEntity>(_context.Set<TEntity>().FirstOrDefault(f => f.Id == id));
                return _result;
            }catch(Exception ex)
            {
                throw new Exception($@"Erro ao Buscar. {ex.Message}");
            }
        }

        public async Task<TModel> Insert(TModel model)
        {
            try
            {
                var entity = _mapper.Map<TEntity, TModel>(model);
                _context.Set<TEntity>().Add(entity);
                _context.SaveChanges();
                return _mapper.Map<TModel, TEntity>(entity);
            }catch(Exception ex)
            {
                throw new Exception($@"Erro ao Cadastrar. {ex.Message}");
            }
        }

        public async Task<TModel> Update(TModel model)
        {
            try
            {
                TEntity entity = _mapper.Map<TEntity, TModel>(model);
                entity.DataAlteracao = DateTime.Now;

                var entry = _context.Entry(entity);
                entry.State = EntityState.Modified;
                _context.SaveChanges();

                return _mapper.Map<TModel, TEntity>(entity);
            }catch(Exception ex)
            {
                throw new Exception($@"Erro ao Atualizar. {ex.Message}");
            }
        }

        public async Task<int> Count(Expression<Func<TModel, bool>> predicate = null)
        {
            try
            {
                int count = 0;
                if (predicate == null)
                    count = _context.Set<TEntity>().Count();
                else
                    count = _context.Set<TModel>().Where(predicate).Count();

                return count;
            }catch(Exception ex)
            {
                throw new Exception($@"Erro ao contar. {ex.Message}");
            }
        }
        protected IQueryable<TEntity> QueryList(IQueryable<TEntity> query, PaginateRequest<TFilter> paginate)
        {
            var filtros = Filtrar(paginate.filtro);
            if (filtros != null)
                foreach (var filtro in filtros)
                    query = query.Where(filtro);

            if (paginate.order != null && paginate.order.order == "desc")
                query = query.OrderByDescending(GetOrderBy(paginate.order.nome));
            else
                query = query.OrderBy(GetOrderBy(paginate.order.nome));

            return query;
        }
        protected Expression<Func<TEntity, object>> GetOrderBy(string key)
        {
            var type = typeof(TEntity);
            foreach (var property in type.GetProperties().Where(x => !x.GetGetMethod().IsVirtual).ToList())
            {
                string name = property.GetGetMethod().Name.ToLower().Replace("get_", "");

                if (!string.IsNullOrWhiteSpace(name))
                {
                    if (key.ToLower().Equals(name))
                    {
                        var param = Expression.Parameter(typeof(TEntity), "x");
                        return Expression.Lambda<Func<TEntity, object>>
                            (Expression.Convert(Expression.Property(param, property.Name), typeof(object)), param);
                    }
                }
            }

            return null;
        }
        protected abstract List<Expression<Func<TEntity, bool>>> Filtrar(TFilter filtro);
    }
}
