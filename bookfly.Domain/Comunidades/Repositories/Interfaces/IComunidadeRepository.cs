

using bookfly.Domain.Comunidades.Entities;
using bookfly.Domain.Comunidades.Repositories.Filters;

namespace bookfly.Domain.Comunidades.Repositories.Interfaces
{
    public interface IComunidadeRepository
    {
        IQueryable<Comunidade> Filtrar();
        Task InserirAsync(Comunidade comunidade, CancellationToken cancellationToken);
        Task EditarAsync(Comunidade comunidade, CancellationToken cancellationToken);
        Task<Comunidade?> RecuperarPorIdAsync(int comunidadeId, CancellationToken cancellationToken);

        Task<List<Comunidade>> ListarAsync(ComunidadeFiltro comunidade, CancellationToken cancellationToken);
    }
}