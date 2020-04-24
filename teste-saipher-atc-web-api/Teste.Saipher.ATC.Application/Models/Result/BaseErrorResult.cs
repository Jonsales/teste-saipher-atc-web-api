using System;

namespace Teste.Saipher.ATC.Application.Models.Result
{
    public class BaseErrorResult
    {
        public string Titulo { get; set; }

        public string Mensagem { get; set; }
        public Exception Exception { get; set; } = null;
    }
}
