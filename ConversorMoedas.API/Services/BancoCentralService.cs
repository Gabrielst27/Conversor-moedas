using ConversorMoedas.API.Models;
using System.Text.Json;

namespace ConversorMoedas.API.Services
{
    public class BancoCentralService : IBancoCentralService
    {
        private readonly HttpClient _httpClient;

        public BancoCentralService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<Moeda> ObterCotacaoUSDAsync()
        {
            var endpoint = $"https://olinda.bcb.gov.br/olinda/servico/PTAX/versao/v1/odata/CotacaoDolarDia(dataCotacao=@dataCotacao)?@dataCotacao='09-04-2024'&$top=1&$format=json";

            var response = await _httpClient.GetAsync(endpoint);

            if (response.IsSuccessStatusCode)
            {
                var jsonResponse = await response.Content.ReadAsStringAsync();
                Console.WriteLine("JSON Response: " + jsonResponse);

                var cotacaoDolarDia = JsonSerializer.Deserialize<ListaMoeda>(jsonResponse, new JsonSerializerOptions
                {
                    PropertyNameCaseInsensitive = true
                });

                MoedaResponse moedaResponse = cotacaoDolarDia.Value[0];

                return new Moeda
                {
                    Nome = "Dolar",
                    Pais = "EUA",
                    PrecoCompra = moedaResponse.CotacaoVenda,
                    PrecoVenda = moedaResponse.CotacaoCompra,
                    Cod = "USD",
                    Data = DateTime.Parse(moedaResponse.DataHoraCotacao),
                };
            }
            else
            {
                throw new Exception("Não foi possível obter a cotação.");
            }
        }
    }

    

    
}
