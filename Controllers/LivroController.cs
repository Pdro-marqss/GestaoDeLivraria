using Microsoft.AspNetCore.Mvc;
using GestaoDeLivraria.Dtos;
using GestaoDeLivraria.Communication.Request;

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


    [HttpPut]
    [Route("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public IActionResult AtualizarOsDadosDeUmLivro([FromRoute] string id, [FromBody] RequestAtualizarDadosDoLivro atualizarDadosDoLivro)
    {
        int indexDoLivroQueSeraAtualizado = Livros.FindIndex(book => book.Id == id);
        
        if (indexDoLivroQueSeraAtualizado < 0) return NotFound();
        
        LivroDto livroAtualizado = new LivroDto
        {
            Id = Livros[indexDoLivroQueSeraAtualizado].Id,
            Titulo = atualizarDadosDoLivro.Titulo,
            Autor = atualizarDadosDoLivro.Autor,
            Genero = atualizarDadosDoLivro.Genero,
            Preco = atualizarDadosDoLivro.Preco,
            QuantidadeEmEstoque = atualizarDadosDoLivro.QuantidadeEmEstoque
        };

        Livros[indexDoLivroQueSeraAtualizado] = livroAtualizado;
        
        return Ok(new
        {
            statusCode = StatusCodes.Status200OK,
            message = "Livro atualizado com sucesso.",
            livro = Livros[indexDoLivroQueSeraAtualizado]
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