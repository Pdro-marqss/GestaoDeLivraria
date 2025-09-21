using GestaoDeLivraria.Dtos;
using Microsoft.AspNetCore.Mvc;

namespace GestaoDeLivraria.Controllers;

[Route("api/[controller]")]
[ApiController]
public abstract class GestaoDeLivrariaBaseController : Controller
{
    // Lista estatica que persiste enquanto a API estiver rodando... Esse static + protected para quem herdar esse controller poder acessar. 
    protected static List<LivroDto> Livros = new List<LivroDto>();
    
    [HttpGet("status-da-api")]
    public IActionResult StatusDaApi()
    {
        return Ok("API Funcionando...");
    }
}