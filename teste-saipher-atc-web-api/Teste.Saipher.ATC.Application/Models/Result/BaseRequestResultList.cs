using Teste.Saipher.ATC.Application.Models.ViewModels.Base;
using System;

namespace Teste.Saipher.ATC.Application.Models.Result
{
    public class BaseRequestResultList<TViewModel> : BaseRequestResult<BasePaginateResult<TViewModel>>
        where TViewModel : BaseViewModel
    {
        public override BasePaginateResult<TViewModel> Data { get; set; }

        public BaseRequestResultList(BasePaginateResult<TViewModel> data)
        {
            Data = data;
        }
        public BaseRequestResultList(string titulo, string mensagem)
        {
            Sucesso = false;
            Erro = new BaseErrorResult()
            {
                Mensagem = mensagem,
                Titulo = titulo
            };
        }

        public BaseRequestResultList(Exception ex)
        {
            Sucesso = false;
            Erro = new BaseErrorResult()
            {
                Exception = ex
            };
        }

        public BaseRequestResultList()
        {
        }
    }
}
