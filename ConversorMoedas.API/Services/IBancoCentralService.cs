using ConversorMoedas.API.Models;

namespace ConversorMoedas.API.Services
{
    public interface IBancoCentralService
    {
        Task<Moeda> ObterCotacaoUSDAsync();
        Task<Moeda> ObterCotacaoEURAsync();
        Task<Moeda> ObterCotacaoJPYAsync();
        Task<Moeda> ObterCotacaoSEKAsync();
        Task<Moeda> ObterCotacaoNOKAsync();
        Task<Moeda> ObterCotacaoCADAsync();
    }
}
