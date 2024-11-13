using ConversorMoedas.API.Services;
using Microsoft.AspNetCore.Mvc;
using ConversorMoedas.API.Models;
using ConversorMoedas.API.Context;
using ConversorMoedas.API.Repositories;

namespace YourNamespace.Controllers;

[ApiController]
[Route("api/[controller]")]
public class MoedaController : ControllerBase
{
    private readonly IMoedaDataService _mdService;
    private readonly IMoedaRepository _repository;

    public MoedaController(IMoedaDataService bancoCentralService, IMoedaRepository moedaRepository)
    {
        _mdService = bancoCentralService;
        _repository = moedaRepository;
    }

    [HttpGet("CotacaoAtual")]
    public async Task<IActionResult> GetCotacao(string codigo)
    {
        try
        {
            if (codigo.ToUpper() == "USD")
            {
                var cotacao = await _mdService.ObterCotacaoUSDAsync();
                return Ok(cotacao);
            }
            if (codigo.ToUpper() == "EUR")
            {
                var cotacao = await _mdService.ObterCotacaoEURAsync();
                return Ok(cotacao);
            }
            if (codigo.ToUpper() == "JPY")
            {
                var cotacao = await _mdService.ObterCotacaoJPYAsync();
                return Ok(cotacao);
            }
            if (codigo.ToUpper() == "SEK")
            {
                var cotacao = await _mdService.ObterCotacaoSEKAsync();
                return Ok(cotacao);
            }
            if (codigo.ToUpper() == "NOK")
            {
                var cotacao = await _mdService.ObterCotacaoNOKAsync();
                return Ok(cotacao);
            }
            if (codigo.ToUpper() == "CAD")
            {
                var cotacao = await _mdService.ObterCotacaoCADAsync();
                return Ok(cotacao);
            }

            return BadRequest("Não há registros para o código de moeda especificado");
        }
        catch (Exception ex)
        {
            return StatusCode(500, $"Erro ao obter cotação: {ex.Message}");
        }
    }

    [HttpGet]
    public ActionResult<IEnumerable<Moeda>> Teste()
    {
        return Ok(_repository.GetAll());
    }
}
