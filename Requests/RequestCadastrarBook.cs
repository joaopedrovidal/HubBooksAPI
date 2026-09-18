using HubBooksAPI.Enums;

namespace HubBooksAPI.Requests;

public class RequestCadastrarBook
{
    public string Titulo { get; set; }
    public string Autor { get; set; }
    public GeneroEnum Genero;
    public decimal Preco { get; set;  }
    public int Estoque { get; set; }
}
