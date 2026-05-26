using bookfly.Domain.EstanteLivros.Entities;
using bookfly.Domain.EstanteLivros.Repositories.Filters;

namespace bookfly.Domain.EstanteLivros.Repositories.Interfaces
{
    public interface IEstanteLivrosRepository
    {
        IQueryable<EstanteLivro> Filtrar();
        Task InserirAsync(EstanteLivro estanteLivro, CancellationToken cancellationToken);
        Task EditarAsync(EstanteLivro estanteLivro, CancellationToken cancellationToken);
        Task<EstanteLivro?> RecuperarPorIdAsync(int estanteLivroId, CancellationToken cancellationToken);

        Task<List<EstanteLivro>> ListarAsync(EstanteLivroFiltro estanteLivro, CancellationToken cancellationToken);
    }
}