

using bookfly.Domain.MembrosComunidade.Entities;
using bookfly.Domain.MembrosComunidade.Repositories.Filters;

namespace bookfly.Domain.MembrosComunidade.Repositories
{
    public interface IMembrosComunidadeRepository
    {

        IQueryable<MembroComunidade> Filtrar();
        Task InserirAsync(MembroComunidade MembroComunidade, CancellationToken cancellationToken);
        Task EditarAsync(MembroComunidade MembroComunidade, CancellationToken cancellationToken);
        Task<MembroComunidade?> RecuperarPorIdAsync(int id, CancellationToken cancellationToken);
        Task<List<MembroComunidade>> ListarAsync(MembroComunidadeFiltro filtro, CancellationToken cancellationToken);
    }
}