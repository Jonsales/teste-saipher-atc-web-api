using System;

namespace Teste.Saipher.ATC.Domain.Interfaces.Services.Helper
{
    public interface ILoggerService
    {
        public void GerarLogException(Exception ex, string identificacao, object request = null, int usuarioId = 0,  object body = null);
    }
}
