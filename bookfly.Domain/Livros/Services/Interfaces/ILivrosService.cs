
using bookfly.Domain.Categorias.Entities;
using bookfly.Domain.Livros.Commands;
using bookfly.Domain.Livros.Entities;

namespace bookfly.Domain.Livros.Services.Interfaces
{
    public interface ILivrosService
    {
        Task<Livro> ValidarAsync(int livroId, CancellationToken cancellationToken);
        Task<Livro> InserirLivroAsync(InserirLivroCommand comando, CancellationToken cancellationToken);
        Task<Livro> EditarLivroAsync(EditarLivroCommand comando, int id, CancellationToken cancellationToken);
        Task<List<Livro>> ListarAsync(string titulo, string autor, CancellationToken cancellationToken);
        Livro Instanciar(InserirLivroCommand comando);
        Task MudarSituacaoAsync(int id, CancellationToken cancellationToken);
        Task AdicionarCategoriaAsync(int livroId, Categoria categoria, CancellationToken cancellationToken);
        Task<Livro> CriarLivroViaGoogleAsync(string googleBooksId,int categoriaId,CancellationToken cancellationToken);
    }
}