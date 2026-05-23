using bookfly.Domain.Estantes.Commands;
using bookfly.Domain.Estantes.Entities;
using bookfly.Domain.Estantes.Repositories.Filters;

namespace bookfly.Domain.Estantes.Services.Interfaces
{
    public interface IEstantesService
    {
        Task<Estante> InserirEstanteAsync(InserirEstanteCommand comando, CancellationToken cancellationToken);
        Task<Estante> ValidarAsync(int id, CancellationToken cancellationToken);

        Task<Estante> EditarEstanteAsync(EditarEstanteCommand comando, int id, CancellationToken cancellationToken);
        Estante Instanciar(InserirEstanteCommand comando);
        Task MudarSituacaoAsync(int id, CancellationToken cancellationToken);

        Task<List<Estante>> ListarAsync(EstanteFiltro categoria, CancellationToken cancellationToken);
    }
}