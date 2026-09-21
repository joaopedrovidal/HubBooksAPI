

using HubBooksAPI.Enums;

namespace HubBooksAPI.Requests;

public class RequestCadastrarEditarBook
{
    public string Titulo { get; set; } = string.Empty;
    public string Autor { get; set; } = string.Empty;
    public decimal Preco { get; set; }
    public int Estoque { get; set; }
    public GeneroEnum Genero { get; set; }
}
