# # 📚 HubBooks API

API REST desenvolvida em **C# com ASP.NET Core** para gerenciamento de livros.

O projeto permite realizar operações de cadastro, consulta, edição e exclusão de livros (CRUD).

## 🚀 Tecnologias utilizadas

- C#
- .NET
- ASP.NET Core Web API
- Swagger
- HTTP/REST

## 📋 Funcionalidades

A API possui as seguintes operações:

- Criar um livro;
- Listar todos os livros;
- Buscar um livro pelo ID;
- Editar um livro;
- Excluir um livro.

Cada livro possui:

- ID único gerado automaticamente com `Guid`;
- Título;
- Autor;
- Gênero;
- Preço;
- Estoque;
- Data de criação;
- Data de atualização.

## ⚙️ Pré-requisitos

Para executar o projeto, é necessário ter instalado:

- [.NET SDK](https://dotnet.microsoft.com/download)

Para verificar se o .NET está instalado:

```bash
dotnet --version