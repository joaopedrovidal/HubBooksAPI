using HubBooksAPI.Enums;

namespace HubBooksAPI.Models;

public class Book
{
    public Guid Id { get; set; } = new Guid();
    public string Titulo { get; set; } = string.Empty;
    public string Autor { get; set; } = string.Empty;
    public GeneroEnum Genero;
    public decimal Preco { get; set; }
    public int Estoque{ get; set; }

    public void CadastrarLivro(string titulo, string autor, GeneroEnum genero, decimal preco, int estoque)
    {
        Titulo = titulo;
        Autor = autor;
        Genero = genero;
        Preco = preco;
        Estoque = estoque;
    }
}
