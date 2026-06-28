using bookfly.Domain.CargosComunidade.Entities;
using bookfly.Domain.CargosComunidade.Repositories.Filters;

namespace bookfly.Domain.CargosComunidade.Repositories.Interfaces
{
    public interface ICargoComunidadeRepository
    {
        IQueryable<CargoComunidade> Filtrar();
        Task InserirAsync(CargoComunidade cargoComunidade, CancellationToken cancellationToken);
        Task EditarAsync(CargoComunidade cargoComunidade, CancellationToken cancellationToken);
        Task<CargoComunidade?> RecuperarPorIdAsync(int id, CancellationToken cancellationToken);
        Task<List<CargoComunidade>> ListarAsync(CargoComunidadeFiltro filtro, CancellationToken cancellationToken);
    }
}
