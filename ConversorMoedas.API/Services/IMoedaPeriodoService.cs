using ConversorMoedas.API.Models;

namespace ConversorMoedas.API.Services
{
    public interface IMoedaPeriodoService
    {
        Task<IEnumerable<ListaMoeda>> ObterCotacoesUSDAsync();
        Task<IEnumerable<ListaMoeda>> ObterCotacoesEURAsync();
        Task<IEnumerable<ListaMoeda>> ObterCotacoesCADAsync();
        Task<IEnumerable<ListaMoeda>> ObterCotacoesSEKAsync();
        Task<IEnumerable<ListaMoeda>> ObterCotacoesNOKAsync();
        Task<IEnumerable<ListaMoeda>> ObterCotacoesJPYAsync();
    }
}
