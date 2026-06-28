using bookfly.Domain.CargosComunidade.Commands;
using bookfly.Domain.CargosComunidade.Entities;
using bookfly.Domain.CargosComunidade.Repositories.Filters;

namespace bookfly.Domain.CargosComunidade.Services.Interfaces
{
    public interface ICargoComunidadeService
    {
        Task<CargoComunidade> InserirCargoComunidadeAsync(InserirCargoComunidadeCommand comando, CancellationToken cancellationToken);
        Task<CargoComunidade> EditarCargoComunidadeAsync(EditarCargoComunidadeCommand comando, int id, CancellationToken cancellationToken);
        Task<List<CargoComunidade>> ListarAsync(CargoComunidadeFiltro filtro, CancellationToken cancellationToken);
        Task<CargoComunidade> ValidarAsync(int id, CancellationToken cancellationToken);
        CargoComunidade Instanciar(InserirCargoComunidadeCommand comando);
    }
}
