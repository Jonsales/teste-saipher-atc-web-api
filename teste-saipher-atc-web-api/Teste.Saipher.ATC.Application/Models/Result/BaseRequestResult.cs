namespace Teste.Saipher.ATC.Application.Models.Result
{
    public abstract class BaseRequestResult<TViewModel>
    {
        public abstract TViewModel Data { get; set; }
        public bool Sucesso { get; set; } = true;

        public BaseErrorResult Erro { get; set; }

        public BaseRequestResult()
        {
        }
    }
}
