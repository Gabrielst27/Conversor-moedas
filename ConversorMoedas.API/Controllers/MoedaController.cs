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
    private readonly IBancoCentralService _bcService;
    private readonly IMoedaRepository _repository;

    public MoedaController(IBancoCentralService bancoCentralService, IMoedaRepository moedaRepository)
    {
        _bcService = bancoCentralService;
        _repository = moedaRepository;
    }

    [HttpGet("CotacaoAtual")]
    public async Task<IActionResult> GetCotacao(string codigo)
    {
        try
        {
            if (codigo.ToUpper() == "USD")
            {
                var cotacao = await _bcService.ObterCotacaoUSDAsync();
                return Ok(cotacao);
            }
            if (codigo.ToUpper() == "EUR")
            {
                var cotacao = await _bcService.ObterCotacaoEURAsync();
                return Ok(cotacao);
            }
            if (codigo.ToUpper() == "JPY")
            {
                var cotacao = await _bcService.ObterCotacaoJPYAsync();
                return Ok(cotacao);
            }
            if (codigo.ToUpper() == "SEK")
            {
                var cotacao = await _bcService.ObterCotacaoSEKAsync();
                return Ok(cotacao);
            }
            if (codigo.ToUpper() == "NOK")
            {
                var cotacao = await _bcService.ObterCotacaoNOKAsync();
                return Ok(cotacao);
            }
            if (codigo.ToUpper() == "CAD")
            {
                var cotacao = await _bcService.ObterCotacaoCADAsync();
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
