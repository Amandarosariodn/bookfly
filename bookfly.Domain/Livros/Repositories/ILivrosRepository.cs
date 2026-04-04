using bookfly.Domain.Livros.Entities;

namespace bookfly.Domain.Livros.Repositories
{
    public interface ILivrosRepository
    {
        Task<Livro> RecuperarPorIdAsync(int livroId, CancellationToken cancellationToken);
        Task InserirAsync(Livro livro, CancellationToken cancellationToken);
        Task EditarAsync(Livro livro, CancellationToken cancellationToken);
        Task<List<Livro>> ListarAsync(string titulo, string autor, CancellationToken cancellationToken);
        
    }
}