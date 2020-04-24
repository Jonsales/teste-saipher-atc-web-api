using Microsoft.Extensions.Configuration;
using Teste.Saipher.ATC.Domain.Interfaces.Services.Helper;
using System;

namespace Teste.Saipher.ATC.CrossCutting
{
    public class HelperService : IHelperService
    {
        private readonly IConfiguration _config;

        public HelperService(IConfiguration config)
        {
            _config = config;
        }

        public string GetConnectionString()
        {
            return _config.GetConnectionString("DefaultConnection");
        }

        public int GetQuantidadePorPaginaDefault()
        {
            var quantidade = _config.GetValue<int>("Settings:DefaultQuantidadePagina");
            return quantidade;
        }

        public TResult Map<TResult, TConvert>(TConvert convert)
        {
            throw new NotImplementedException();
        }

    }
}
