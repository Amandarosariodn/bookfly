using bookfly.Application.Livros.DataTransfer.Requests;
using bookfly.Application.Livros.DataTransfer.Responses;
using bookfly.Domain.GoogleBooks.Commands;
using bookfly.Domain.GoogleBooks.Entities;
using bookfly.Domain.Livros.Commands;
using bookfly.Domain.Livros.Entities;
using Mapster;

namespace bookfly.Application.Livros.Profiles
{
    public class LivrosProfile : IRegister
    {
        public void Register(TypeAdapterConfig config)
        {
            config.NewConfig<InserirLivroRequest, InserirLivroCommand>();
            config.NewConfig<EditarLivroRequest, EditarLivroCommand>();
            config.NewConfig<ListarLivroRequest, ListarLivroCommand>();
            config.NewConfig<Livro, LivroResponse>();
            config.NewConfig<InserirLivroViaGoogleRequest, InserirLivroViaGoogleCommand>();
            config.NewConfig<Item, GoogleBooksResponse>();
        }
    }
}