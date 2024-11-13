using ConversorMoedas.API.Models;
using System.Text.Json;

namespace ConversorMoedas.API.Services
{
    public class MoedaDataService : IMoedaDataService
    {
        private readonly HttpClient _httpClient;

        public MoedaDataService(HttpClient httpClient)
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

                        int spaceIndex = data.ToString().IndexOf(' ');

                        Moeda moeda = new Moeda
                        {
                            Id = spaceIndex <= 0 ? data.ToString("yyyy/MM/dd").Replace("/", "") : data.ToString("yyyy/MM/dd").Substring(0, spaceIndex).Replace("/",""),
                            Nome = "Dolar",
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

        public async Task<Moeda> ObterCotacaoEURAsync()
        {
            int i;

            for (i = 0; i < 15; i++)
            {
                DateTime data = DateTime.Now.AddDays(-i);
                string dataAtual = data.ToString("MM-dd-yyyy");
                var endpoint = $"https://olinda.bcb.gov.br/olinda/servico/PTAX/versao/v1/odata/CotacaoMoedaDia(moeda=@moeda,dataCotacao=@dataCotacao)?@moeda='EUR'&@dataCotacao='{dataAtual}'&$top=100&$format=json&$select=cotacaoCompra,cotacaoVenda,dataHoraCotacao";

                var response = await _httpClient.GetAsync(endpoint);

                if (response.IsSuccessStatusCode)
                {
                    var jsonResponse = await response.Content.ReadAsStringAsync();
                    Console.WriteLine("JSON Response: " + jsonResponse);

                    var cotacao = JsonSerializer.Deserialize<ListaMoeda>(jsonResponse, new JsonSerializerOptions
                    {
                        PropertyNameCaseInsensitive = true
                    });

                    if (cotacao.Value.Count != 0)
                    {
                        MoedaResponse moedaResponse = cotacao.Value[0];

                        Moeda moeda = new Moeda
                        {
                            Nome = "Euro",
                            PrecoCompra = moedaResponse.CotacaoVenda,
                            PrecoVenda = moedaResponse.CotacaoCompra,
                            Cod = "EUR",
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

        public async Task<Moeda> ObterCotacaoJPYAsync()
        {
            int i;

            for (i = 0; i < 15; i++)
            {
                DateTime data = DateTime.Now.AddDays(-i);
                string dataAtual = data.ToString("MM-dd-yyyy");
                var endpoint = $"https://olinda.bcb.gov.br/olinda/servico/PTAX/versao/v1/odata/CotacaoMoedaDia(moeda=@moeda,dataCotacao=@dataCotacao)?@moeda='JPY'&@dataCotacao='{dataAtual}'&$top=100&$format=json&$select=cotacaoCompra,cotacaoVenda,dataHoraCotacao";

                var response = await _httpClient.GetAsync(endpoint);

                if (response.IsSuccessStatusCode)
                {
                    var jsonResponse = await response.Content.ReadAsStringAsync();
                    Console.WriteLine("JSON Response: " + jsonResponse);

                    var cotacao = JsonSerializer.Deserialize<ListaMoeda>(jsonResponse, new JsonSerializerOptions
                    {
                        PropertyNameCaseInsensitive = true
                    });

                    if (cotacao.Value.Count != 0)
                    {
                        MoedaResponse moedaResponse = cotacao.Value[0];

                        Moeda moeda = new Moeda
                        {
                            Nome = "Iene",
                            PrecoCompra = moedaResponse.CotacaoVenda,
                            PrecoVenda = moedaResponse.CotacaoCompra,
                            Cod = "JPY",
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

        public async Task<Moeda> ObterCotacaoSEKAsync()
        {
            int i;

            for (i = 0; i < 15; i++)
            {
                DateTime data = DateTime.Now.AddDays(-i);
                string dataAtual = data.ToString("MM-dd-yyyy");
                var endpoint = $"https://olinda.bcb.gov.br/olinda/servico/PTAX/versao/v1/odata/CotacaoMoedaDia(moeda=@moeda,dataCotacao=@dataCotacao)?@moeda='SEK'&@dataCotacao='{dataAtual}'&$top=100&$format=json&$select=cotacaoCompra,cotacaoVenda,dataHoraCotacao";

                var response = await _httpClient.GetAsync(endpoint);

                if (response.IsSuccessStatusCode)
                {
                    var jsonResponse = await response.Content.ReadAsStringAsync();
                    Console.WriteLine("JSON Response: " + jsonResponse);

                    var cotacao = JsonSerializer.Deserialize<ListaMoeda>(jsonResponse, new JsonSerializerOptions
                    {
                        PropertyNameCaseInsensitive = true
                    });

                    if (cotacao.Value.Count != 0)
                    {
                        MoedaResponse moedaResponse = cotacao.Value[0];

                        Moeda moeda = new Moeda
                        {
                            Nome = "Cora Sueca",
                            PrecoCompra = moedaResponse.CotacaoVenda,
                            PrecoVenda = moedaResponse.CotacaoCompra,
                            Cod = "SEK",
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

        public async Task<Moeda> ObterCotacaoNOKAsync()
        {
            int i;

            for (i = 0; i < 15; i++)
            {
                DateTime data = DateTime.Now.AddDays(-i);
                string dataAtual = data.ToString("MM-dd-yyyy");
                var endpoint = $"https://olinda.bcb.gov.br/olinda/servico/PTAX/versao/v1/odata/CotacaoMoedaDia(moeda=@moeda,dataCotacao=@dataCotacao)?@moeda='NOK'&@dataCotacao='{dataAtual}'&$top=100&$format=json&$select=cotacaoCompra,cotacaoVenda,dataHoraCotacao";

                var response = await _httpClient.GetAsync(endpoint);

                if (response.IsSuccessStatusCode)
                {
                    var jsonResponse = await response.Content.ReadAsStringAsync();
                    Console.WriteLine("JSON Response: " + jsonResponse);

                    var cotacao = JsonSerializer.Deserialize<ListaMoeda>(jsonResponse, new JsonSerializerOptions
                    {
                        PropertyNameCaseInsensitive = true
                    });

                    if (cotacao.Value.Count != 0)
                    {
                        MoedaResponse moedaResponse = cotacao.Value[0];

                        Moeda moeda = new Moeda
                        {
                            Nome = "Cora Norueguesa",
                            PrecoCompra = moedaResponse.CotacaoVenda,
                            PrecoVenda = moedaResponse.CotacaoCompra,
                            Cod = "NOK",
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

        public async Task<Moeda> ObterCotacaoCADAsync()
        {
            int i;

            for (i = 0; i < 15; i++)
            {
                DateTime data = DateTime.Now.AddDays(-i);
                string dataAtual = data.ToString("MM-dd-yyyy");
                var endpoint = $"https://olinda.bcb.gov.br/olinda/servico/PTAX/versao/v1/odata/CotacaoMoedaDia(moeda=@moeda,dataCotacao=@dataCotacao)?@moeda='CAD'&@dataCotacao='{dataAtual}'&$top=100&$format=json&$select=cotacaoCompra,cotacaoVenda,dataHoraCotacao";

                var response = await _httpClient.GetAsync(endpoint);

                if (response.IsSuccessStatusCode)
                {
                    var jsonResponse = await response.Content.ReadAsStringAsync();
                    Console.WriteLine("JSON Response: " + jsonResponse);

                    var cotacao = JsonSerializer.Deserialize<ListaMoeda>(jsonResponse, new JsonSerializerOptions
                    {
                        PropertyNameCaseInsensitive = true
                    });

                    if (cotacao.Value.Count != 0)
                    {
                        MoedaResponse moedaResponse = cotacao.Value[0];

                        Moeda moeda = new Moeda
                        {
                            Nome = "Dolar Canadense",
                            PrecoCompra = moedaResponse.CotacaoVenda,
                            PrecoVenda = moedaResponse.CotacaoCompra,
                            Cod = "CAD",
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
