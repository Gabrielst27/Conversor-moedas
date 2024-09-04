using ConversorMoedas.API.Models;

namespace ConversorMoedas.API.Services
{
    public interface IBancoCentralService
    {
        Task<Moeda> ObterCotacaoUSDAsync();
    }
}
