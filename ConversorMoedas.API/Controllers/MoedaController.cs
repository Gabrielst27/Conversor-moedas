using ConversorMoedas.API.Services;
using Microsoft.AspNetCore.Mvc;
using ConversorMoedas.API.Models;
using ConversorMoedas.API.Context;

namespace YourNamespace.Controllers;

[ApiController]
[Route("api/[controller]")]
public class MoedaController : ControllerBase
{
    private readonly IBancoCentralService _bcService;
    private readonly PgSQLContext _context;

    public MoedaController(IBancoCentralService bancoCentralService, PgSQLContext context)
    {
        _bcService = bancoCentralService;
        _context = context;
    }

    [HttpGet("moeda")]
    public async Task<IActionResult> GetCotacao(string codigo)
    {
        try
        {
            if (codigo.ToUpper() == "USD")
            {
                var cotacao = await _bcService.ObterCotacaoUSDAsync();
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
        return Ok(_context.Moedas.ToList());
    }
}
