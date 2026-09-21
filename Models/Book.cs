using HubBooksAPI.Enums;

namespace HubBooksAPI.Models;

public class Book
{
    public Guid Id { get; set; } = Guid.NewGuid();
    public string Titulo { get; set; } = string.Empty;
    public string Autor { get; set; } = string.Empty;
    public GeneroEnum Genero { get; set; }
    public decimal Preco { get; set; }
    public int Estoque { get; set; }

    public DateTime Criado_em { get; set; }

    public DateTime? Atualizado_em { get; set; }

    public void CadastrarLivro(string titulo, string autor, GeneroEnum genero, decimal preco, int estoque)
    {
        Titulo = titulo;
        Autor = autor;
        Genero = genero;
        Preco = preco;
        Estoque = estoque;
        Criado_em = DateTime.Now;
    }

    public void EditarLivro(string titulo, string autor, GeneroEnum genero, decimal preco, int estoque)
    {
        Titulo = titulo;
        Autor = autor;
        Genero = genero;
        Preco = preco;
        Estoque = estoque;
        Atualizado_em = DateTime.Now;
    }



    public decimal ValidaPreco(decimal preco)
    {
        if (preco < 0)
        {
            throw new ArgumentException("Informe um valor maior ou igual a 0");
        }

        return preco;
    }

    public string ValidaTitulo(string titulo)
    {
        if (titulo.Length >= 2 && titulo.Length <= 120)
        {
            return titulo;
        }

        throw new Exception("O título deve ter entre 2 a 120 caracteres");
    }

    public string ValidaAutor(string autor)
    {
        if (autor.Length >= 2 && autor.Length <= 120)
        {
            return autor;
        }
        throw new Exception("O Autor deve ter entre 2 a 120 caracteres");
    }

    public int ValidaEstoque(int estoque)
    {
        if (estoque >= 0)
        {
            return estoque;
        }

        throw new Exception("O estoque do livro deve ser maior ou igual a 0");
    }

    public GeneroEnum ValidaGereno(GeneroEnum genero){
        if (!Enum.IsDefined(typeof(GeneroEnum), genero))
        {
            throw new ArgumentException("Gênero inválido!");
        }

        return genero;
    }

}
