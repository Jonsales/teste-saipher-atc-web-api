﻿using Microsoft.EntityFrameworkCore;
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

namespace Teste.Saipher.ATC.Data.Repositories.Base
{
    public class BaseRepository<TModel, TEntity> : IBaseRepository<TModel>
        where TModel : BaseModel
        where TEntity : BaseEntity
    {
        private readonly IMapperService _mapper;
        public readonly Context _context;

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

        public async Task<List<TModel>> Get(int pagAtual, int qtdItensPorPagina)
        {
            try
            {
                _resultList = _context.Set<TModel>().OrderBy(c => c.Id).Skip((pagAtual - 1) * qtdItensPorPagina).Take(qtdItensPorPagina).ToList();
                return _resultList;
            }catch(Exception ex)
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
                _context.Set<TModel>().Add(model);
                _context.SaveChanges();
                return model;
            }catch(Exception ex)
            {
                throw new Exception($@"Erro ao Cadastrar. {ex.Message}");
            }
        }

        public async Task<TModel> Update(TModel model)
        {
            try
            {
                 model.DataAlteracao = DateTime.Now;
                _context.Entry(model).State = EntityState.Modified;
                _context.SaveChanges();
                return model;
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
                    count = _context.Set<TModel>().Count();
                else
                    count = _context.Set<TModel>().Where(predicate).Count();

                return count;
            }catch(Exception ex)
            {
                throw new Exception($@"Erro ao contar. {ex.Message}");
            }
        }
    }
}