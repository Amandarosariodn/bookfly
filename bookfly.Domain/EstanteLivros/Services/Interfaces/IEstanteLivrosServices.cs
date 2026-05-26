using bookfly.Domain.EstanteLivros.Commands;
using bookfly.Domain.EstanteLivros.Entities;
using bookfly.Domain.EstanteLivros.Repositories.Filters;

namespace bookfly.Domain.EstanteLivros.Services.Interfaces
{
    public interface IEstanteLivrosServices
    {
        Task<EstanteLivro?> ValidarAsync(int livroId, CancellationToken cancellationToken);
        Task<EstanteLivro> InserirEstanteLivroAsync(InserirEstanteLivroCommand comando,int estanteLivroId, CancellationToken cancellationToken);
        Task<EstanteLivro> EditarEstanteLivroAsync(EditarEstanteLivroCommand comando, int id, CancellationToken cancellationToken);
        Task<List<EstanteLivro>> ListarAsync(EstanteLivroFiltro filtro,CancellationToken cancellationToken);
        EstanteLivro Instanciar(InserirEstanteLivroCommand comando);
    }
}