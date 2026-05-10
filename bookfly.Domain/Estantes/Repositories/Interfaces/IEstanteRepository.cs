using bookfly.Domain.Estantes.Entities;
using bookfly.Domain.Estantes.Repositories.Filters;

namespace bookfly.Domain.Estantes.Repositories.Interfaces
{
    public interface IEstanteRepository
    {

        IQueryable<Estante> Filtrar();
        Task InserirAsync(Estante estante, CancellationToken cancellationToken);
        Task EditarAsync(Estante estante, CancellationToken cancellationToken);
        Task<Estante?> RecuperarPorIdAsync(int estanteId, CancellationToken cancellationToken);

        Task<List<Estante>> ListarAsync(EstanteFiltro estante, CancellationToken cancellationToken);    }
}