using GestaoDeLivraria.Communication.Request;
using GestaoDeLivraria.Dtos;
using Microsoft.AspNetCore.Mvc;

namespace GestaoDeLivraria.Controllers;

public class LivroController : GestaoDeLivrariaBaseController
{
    [HttpGet]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public IActionResult BuscarTodosOsLivros()
    {
        return Ok(new
        {
            statusCode = StatusCodes.Status200OK,
            message = "Lista de livros cadastrados",
            livros = Livros
        });
    }

    
    [HttpPost]
    [ProducesResponseType(typeof(LivroDto) ,StatusCodes.Status201Created)]
    public IActionResult AdicionarNovoLivro([FromBody] RequestAdicionarNovoLivro request)
    {

        LivroDto novoLivroComId = new LivroDto()
        {
            Id = Guid.NewGuid().ToString("N"),
            Titulo = request.Titulo,
            Autor = request.Autor,
            Genero = request.Genero,
            Preco = request.Preco,
            QuantidadeEmEstoque = request.QuantidadeEmEstoque
        };
        
        Livros.Add(novoLivroComId);
        
        return Created(string.Empty ,new
        {
            statusCode = StatusCodes.Status201Created,
            message = "Livro adicionado com sucesso.",
            dadosDoLivro = novoLivroComId
        });
    }


    [HttpDelete]
    [Route("{id}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public IActionResult ExcluirUmLivroPeloId([FromRoute] string id)
    {
        LivroDto? livroQueSeraRemovido = Livros.Find(livro => livro.Id == id);

        if (livroQueSeraRemovido == null)
        {
            return NotFound("ID não encontrado.");
        }

        Livros.Remove(livroQueSeraRemovido);
        
        return NoContent();
    }
}