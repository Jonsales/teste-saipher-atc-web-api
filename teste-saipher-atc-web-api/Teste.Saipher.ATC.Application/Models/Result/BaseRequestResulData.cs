using Teste.Saipher.ATC.Application.Models.ViewModels.Base;
using System;

namespace Teste.Saipher.ATC.Application.Models.Result
{
    public class BaseRequestResulData<TViewModel> : BaseRequestResult<TViewModel>
        where TViewModel : BaseViewModel
    {
        public override TViewModel Data { get; set; }

        public BaseRequestResulData(string titulo, string mensagem)
        {
            Sucesso = false;
            Erro = new BaseErrorResult()
            {
                Mensagem = mensagem,
                Titulo = titulo
            };
        }

        public BaseRequestResulData(Exception ex)
        {
            Sucesso = false;
            Erro = new BaseErrorResult()
            {
                Exception = ex
            };
        }

        public BaseRequestResulData(TViewModel data)
        {
            Data = data;
        }

        public BaseRequestResulData()
        {
        }
    }
}
