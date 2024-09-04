using ConversorMoedas.API.Services;
using Microsoft.AspNetCore.Mvc;
using ConversorMoedas.API.Models;

namespace YourNamespace.Controllers;

[ApiController]
[Route("api/[controller]")]
public class MoedaController : ControllerBase
{
    private readonly BancoCentralService _bancoCentralService;

    public MoedaController(BancoCentralService bancoCentralService)
    {
        _bancoCentralService = bancoCentralService;
    }

    [HttpGet("moeda")]
    public async Task<IActionResult> GetCotacao(string codigo)
    {
        try
        {
            if (codigo.ToUpper() == "USD")
            {
                var cotacao = await _bancoCentralService.ObterCotacaoUSDAsync();
                return Ok(cotacao);
            }

            return BadRequest("Não há registros para o código de moeda especificado");
        }
        catch (Exception ex)
        {
            return StatusCode(500, $"Erro ao obter cotação: {ex.Message}");
        }
    }
}
