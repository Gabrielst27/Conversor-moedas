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
            int i;

            for (i = 0;i < 15; i++)
            {
                DateTime data = DateTime.Now.AddDays(-i);
                string dataAtual = data.ToString("MM-dd-yyyy");
                var endpoint = $"https://olinda.bcb.gov.br/olinda/servico/PTAX/versao/v1/odata/CotacaoDolarDia(dataCotacao=@dataCotacao)?@dataCotacao='{dataAtual}'&$top=1&$format=json";

                var response = await _httpClient.GetAsync(endpoint);

                if (response.IsSuccessStatusCode)
                {
                    var jsonResponse = await response.Content.ReadAsStringAsync();
                    Console.WriteLine("JSON Response: " + jsonResponse);

                    var cotacaoDolarDia = JsonSerializer.Deserialize<ListaMoeda>(jsonResponse, new JsonSerializerOptions
                    {
                        PropertyNameCaseInsensitive = true
                    });

                    if (cotacaoDolarDia.Value.Count != 0)
                    {
                        MoedaResponse moedaResponse = cotacaoDolarDia.Value[0];

                        Moeda moeda = new Moeda
                        {
                            Nome = "Dolar",
                            Pais = "EUA",
                            PrecoCompra = moedaResponse.CotacaoVenda,
                            PrecoVenda = moedaResponse.CotacaoCompra,
                            Cod = "USD",
                            Data = DateTime.Parse(moedaResponse.DataHoraCotacao),
                        };

                        if (moeda.PrecoVenda != 0)
                        {
                            return moeda;
                        }
                    }
                }
            }

            throw new Exception("Não foi possível obter a cotação.");
        }
    }

    

    
}
