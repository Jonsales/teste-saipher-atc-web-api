using Teste.Saipher.ATC.Application.Interfaces.Base;
using Teste.Saipher.ATC.Application.Models.Request;
using Teste.Saipher.ATC.Application.Models.Result;
using Teste.Saipher.ATC.Application.Models.ViewModels.Base;
using Teste.Saipher.ATC.Domain.Class.Filters;
using Teste.Saipher.ATC.Domain.Class.Models.Base;
using Teste.Saipher.ATC.Domain.Interfaces.Filter;
using Teste.Saipher.ATC.Domain.Interfaces.Services.Base;
using Teste.Saipher.ATC.Domain.Interfaces.Services.Helper;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Teste.Saipher.ATC.Application.AppServices.Base
{
    public abstract class BaseAppService<TService, TViewModel, TModel, TFilter> : IBaseAppService<TViewModel, TFilter>
        where TService : IBaseService<TModel, TFilter>
        where TViewModel : BaseViewModel
        where TModel : BaseModel
        where TFilter : BaseFilter
    {
        internal abstract string Name { get; set; }

        protected readonly TService _service;
        protected readonly IMapperService _mapper;
        protected readonly IHelperService _helper;

        public BaseAppService(TService service, IMapperService mapper, IHelperService helper)
        {
            if (String.IsNullOrWhiteSpace(Name))
                this.Name = "";
            _service = service;
            _mapper = mapper;
            _helper = helper;
        }
        public async Task<BaseRequestResulData<TViewModel>> Atualizar(TViewModel model)
        {
            try
            {
                var map = _mapper.Map<TModel, TViewModel>(model);
                var ret = _mapper.Map<TViewModel, TModel>(await _service.Atualizar(map));
                return new BaseRequestResulData<TViewModel>(ret);
            }
            catch (Exception ex)
            {
                return VerificaException(ex, $@"Não foi possível atualizar {Name}.");
            }
        }

        public async Task<BaseRequestResulData<TViewModel>> Buscar(int id)
        {
            try
            {
                var ret = _mapper.Map<TViewModel, TModel>(await _service.Buscar(id));
                return new BaseRequestResulData<TViewModel>(ret);
            }
            catch (Exception ex)
            {
                return VerificaException(ex, $@"Não foi possível buscar {Name}.");
            }
        }

        public async Task<BaseRequestResulData<TViewModel>> Criar(TViewModel model)
        {
            try
            {
                var ret = _mapper.Map<TViewModel, TModel>(await _service.Criar(_mapper.Map<TModel, TViewModel>(model)));
                return new BaseRequestResulData<TViewModel>(ret);
            }
            catch (Exception ex)
            {
                return VerificaException(ex, $@"Não foi possível cadastrar {Name}.");
            }
        }

        public async Task<BaseRequestResulData<TViewModel>> Deletar(int id)
        {
            try
            {
                await _service.Deletar(id);
                return new BaseRequestResulData<TViewModel>();
            }
            catch (Exception ex)
            {
                return VerificaException(ex, $@"Não foi possível deletar o {Name}.");
            }
        }

        public async Task<BaseRequestResultList<TViewModel>> Listar(PaginateRequest<TFilter> filtroRequest)
        {
            try
            {
                var quantidadePorPagina = VerificarQuantidadePadrao(filtroRequest.quantidadePorPagina);
                var ret = _mapper.Map<List<TViewModel>, List<TModel>>(await _service.Listar(filtroRequest.filtro, filtroRequest.paginaAtual, quantidadePorPagina));
                var total = await _service.Count();

                return new BaseRequestResultList<TViewModel>(
                    new BasePaginateResult<TViewModel>(ret, filtroRequest.paginaAtual, total, quantidadePorPagina));
            }
            catch (Exception ex)
            {
                return VerificaExceptionList(ex, $@"Não foi possível verificar as {Name}.");
            }
        }

        private int VerificarQuantidadePadrao(int? quantidade)
        {
            if (!quantidade.HasValue)
                return _helper.GetQuantidadePorPaginaDefault();
            else
                return quantidade.Value;
        }

        protected BaseRequestResulData<TViewModel> VerificaException(Exception ex, string mensagem)
        {
            if (ex.InnerException != null && ex.InnerException.Message == "ERROR")
                return new BaseRequestResulData<TViewModel>($@"{mensagem}", $@"{ex.Message}");
            return new BaseRequestResulData<TViewModel>(ex);
        }
        protected BaseRequestResultList<TViewModel> VerificaExceptionList(Exception ex, string mensagem)
        {
            if (ex.InnerException != null && ex.InnerException.Message == "ERROR")
                return new BaseRequestResultList<TViewModel>($@"{mensagem}", $@"{ex.Message}");
            return new BaseRequestResultList<TViewModel>(ex);
        }
    }
}
