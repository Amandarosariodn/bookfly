using bookfly.Domain.Estantes.Entities;

namespace bookfly.Domain.Estantes.Services.Interfaces
{
    public interface IEstantesService
    {
        Task<Estante> InserirEstanteAsync(InserirCategoriaCommand comando, CancellationToken cancellationToken);
        Task<Estante> ValidarAsync(int id, CancellationToken cancellationToken);

        Task<Estante> EditarEstanteAsync(EditarCategoriaCommand comando, int id, CancellationToken cancellationToken);
        Estante Instanciar(InserirCategoriaCommand comando);
        Task MudarSituacaoAsync(int id, CancellationToken cancellationToken);

        Task<List<Estante>> ListarAsync(CategoriaFiltro categoria, CancellationToken cancellationToken);
    }
}