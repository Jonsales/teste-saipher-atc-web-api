namespace Teste.Saipher.ATC.Domain.Interfaces.Services.Helper
{
    public interface IHelperService
    {
        string GetConnectionString();
        int GetQuantidadePorPaginaDefault();
        TResult Map<TResult, TConvert>(TConvert convert);
    }
}
