using HubBooksAPI.Models;
using HubBooksAPI.Requests;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HubBooksAPI.Controllers;

[Route("api/[controller]")]
[ApiController]
public class LivroController : ControllerBase
{
    [HttpPost]
    [ProducesResponseType(StatusCodes.Status201Created)]
    public IActionResult CadastrarLivro([FromBody] RequestCadastrarBook request)
    {
        var book = new Book();

        book.CadastrarLivro(request.Titulo, request.Autor, request.Genero, request.Preco, request.Estoque);

        return Created(string.Empty, book);
    }

    [HttpGet]
    [ProducesResponseType(typeof(List<Book>), StatusCodes.Status200OK)]
    public IActionResult BuscarLivros()
    {
        return Ok();
    }

    [HttpGet]
    [Route("ObterPorId")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public IActionResult ObterLivroPorId([FromQuery] Guid id)
    {
        return Ok();
    }

    [HttpPut]
    [Route("{id}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    public IActionResult AtualizarLivro([FromRoute] Guid id)
    {
        return NoContent();
    }

    [HttpDelete]
    [Route("{id}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    public IActionResult ExcluirLivro([FromRoute] Guid id)
    {
        return NoContent();
    }
}
