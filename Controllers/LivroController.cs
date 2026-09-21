using HubBooksAPI.Models;
using HubBooksAPI.Requests;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HubBooksAPI.Controllers;

[Route("api/[controller]")]
[ApiController]
public class LivroController : ControllerBase
{
    private static List<Book> _livors = new();

    [HttpPost]
    [ProducesResponseType(StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status409Conflict)]
    public IActionResult CadastrarLivro([FromBody] RequestCadastrarEditarBook request)
    {
        try
        {
            var book = new Book();
            var livroExistente = _livors.Any(livro => livro.Titulo == request.Titulo && livro.Autor == request.Autor);

            if (livroExistente)
            {
                return Conflict("Já existe um livro com esete título e autor!");
            }


            book.CadastrarLivro(book.ValidaTitulo(request.Titulo), book.ValidaAutor(request.Autor), book.ValidaGereno(request.Genero), book.ValidaPreco(request.Preco), book.ValidaEstoque(request.Estoque));

            _livors.Add(book);

            return Created(string.Empty, book);
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
        
    }

    [HttpGet]
    [ProducesResponseType(typeof(List<Book>), StatusCodes.Status200OK)]
    public IActionResult BuscarLivros()
    {
        return Ok(_livors);
    }

    [HttpGet]
    [Route("ObterPorId")]
    [ProducesResponseType(typeof(Book), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public IActionResult ObterLivroPorId([FromQuery] Guid id)
    {
        var livro = _livors.FirstOrDefault(livro => livro.Id == id);

        if(livro == null)
        {
            return NotFound();
        }

        return Ok(livro);
    }

    [HttpPut]
    [Route("{id}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public IActionResult AtualizarLivro([FromRoute] Guid id, [FromBody]RequestCadastrarEditarBook request)
    {
        try
        {
            var livroQueSeraEditado = _livors.FirstOrDefault(livro => livro.Id == id);

            if (livroQueSeraEditado == null)
            {
                return NotFound();
            }

            livroQueSeraEditado.EditarLivro(livroQueSeraEditado.ValidaTitulo(request.Titulo), livroQueSeraEditado.ValidaAutor(request.Autor), livroQueSeraEditado.ValidaGereno(request.Genero), livroQueSeraEditado.ValidaPreco(request.Preco), livroQueSeraEditado.ValidaEstoque(request.Estoque));

            return NoContent();
        }
        catch(Exception ex)
        {
            return BadRequest(ex.Message);
        }        
        
    }

    [HttpDelete]
    [Route("{id}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public IActionResult ExcluirLivro([FromRoute] Guid id)
    {
        try
        {
            var livroQueSeraDeletado = _livors.FirstOrDefault(livro => livro.Id == id);

            if(livroQueSeraDeletado == null){
                return NotFound();
            }

            _livors.Remove(livroQueSeraDeletado);

            return NoContent();

        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }
}
