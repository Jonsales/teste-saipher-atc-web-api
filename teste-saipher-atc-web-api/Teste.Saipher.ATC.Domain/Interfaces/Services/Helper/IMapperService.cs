namespace Teste.Saipher.ATC.Domain.Interfaces.Services.Helper
{
    public interface IMapperService
    {
        TResult Map<TResult, TSource>(TSource convert);
    }
}
