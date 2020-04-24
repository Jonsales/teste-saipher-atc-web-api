using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json.Linq;
using Teste.Saipher.ATC.Application.Interfaces;
using Teste.Saipher.ATC.Application.Interfaces.Base;
using Teste.Saipher.ATC.Application.Models.Request;
using Teste.Saipher.ATC.Application.Models.Result;
using Teste.Saipher.ATC.Application.Models.ViewModels.Base;
using Teste.Saipher.ATC.Domain.Class.Filters;
using Teste.Saipher.ATC.Domain.Interfaces.Services.Helper;
using System;
using System.IO;
using System.Text;
using System.Threading.Tasks;

namespace Teste.Saipher.ATC.WebAPI.Controllers.Base
{
    [Route("api/[controller]")]
    [ApiController]
    public class BaseController<TAppService, TViewModel, TFilter> : ControllerBase
        where TAppService : IBaseAppService<TViewModel, TFilter>
        where TViewModel : BaseViewModel
        where TFilter : BaseFilter
    {
        protected readonly TAppService _appService;
        private readonly ILoggerService _loggerService;
        public BaseController(TAppService appService, ILoggerService loggerService)
        {
            _appService = appService;
            _loggerService = loggerService;
        }

        [HttpPost]
        [Route("paginate")]
        public async Task<ActionResult> get([FromBody] PaginateRequest<TFilter> paginateRequest) =>
            await this.Result(() => _appService.Listar(paginateRequest));

        [HttpGet]
        [Route("{id}")]
        public async Task<ActionResult> get(int id) =>
            await this.Result(() => _appService.Buscar(id));

        [HttpPut]
        [Route("")]
        public async Task<ActionResult> update([FromBody]TViewModel viewModel) =>
            await this.Result(() => _appService.Atualizar(viewModel));

        [HttpPost]
        [Route("")]
        public async Task<ActionResult> insert([FromBody]TViewModel viewModel) =>
            await this.Result(() => _appService.Criar(viewModel));

        [HttpDelete]
        [Route("{id}")]
        public async Task<ActionResult> delete([FromBody]int id) =>
            await this.Result(() => _appService.Deletar(id));

        protected async Task<ActionResult> Result(Func<Task<BaseRequestResulData<TViewModel>>> invoker, object body = null)
        {
            try
            {
                
                if (invoker != null)
                {
                    var ret = await invoker.Invoke();
                    if (ret.Sucesso)
                    {
                        if (ret.Data == null)
                            return NoContent();
                        return Ok(ret);
                    }
                    else if (ret.Erro.Exception == null)
                        return (ActionResult)BadRequest(ret);
                    else
                    {
                        _loggerService.GerarLogException(ret.Erro.Exception, "", request: Request, body: body);
                        return StatusCode(StatusCodes.Status500InternalServerError,
                            new BaseRequestResultList<TViewModel>
                            ($@"Houve um erro desconhecido.",
                            $@"Aconteceu um erro desconhecido em nosso sistema. Foi criado um relatório para que os nossos desenvolvedores solucionem esse problema ;). Erro: 
                        {ret.Erro.Exception.Message}"));
                    }
                }
                return NotFound();
            }
            catch (Exception ex)
            {
                _loggerService.GerarLogException(ex, "", request: Request, body: body);
                return StatusCode(StatusCodes.Status500InternalServerError, new BaseRequestResulData<TViewModel>(
                    $@"Houve um erro desconhecido.", 
                    $@"Aconteceu um erro desconhecido em nosso sistema. Foi criado um relatório para que os nossos desenvolvedores solucionem esse problema ;). Erro: 
                    {ex.Message}"));
            }
        }

        protected async Task<ActionResult> Result(Func<Task<BaseRequestResultList<TViewModel>>> invoker, object body = null)
        {
            try
            {
                if (invoker != null)
                {
                    var ret = await invoker.Invoke();
                    if (ret.Sucesso)
                    {
                        if (ret.Data == null)
                            return (ActionResult)NoContent();
                        return (ActionResult)Ok(ret);
                    }
                    else if(ret.Erro.Exception == null)
                        return (ActionResult)BadRequest(ret);
                    else
                    {
                        _loggerService.GerarLogException(ret.Erro.Exception, "", request: Request, body: body);
                        return StatusCode(StatusCodes.Status500InternalServerError,
                            new BaseRequestResultList<TViewModel>
                            ($@"Houve um erro desconhecido.",
                            $@"Aconteceu um erro desconhecido em nosso sistema. Foi criado um relatório para que os nossos desenvolvedores solucionem esse problema ;). Erro: 
                        {ret.Erro.Exception.Message}"));
                    }

                }
                return (ActionResult)NotFound();
            }
            catch (Exception ex)
            {
                _loggerService.GerarLogException(ex, "", request: Request, body: body);
                return StatusCode(StatusCodes.Status500InternalServerError, 
                    new BaseRequestResultList<TViewModel>
                    ($@"Houve um erro desconhecido.", 
                    $@"Aconteceu um erro desconhecido em nosso sistema. Foi criado um relatório para que os nossos desenvolvedores solucionem esse problema ;). Erro: 
                    {ex.Message}"));
            }
        }       
    }
}
