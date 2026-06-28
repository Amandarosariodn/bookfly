using bookfly.Domain.MembrosComunidade.Commands;
using bookfly.Domain.MembrosComunidade.Entities;
using bookfly.Domain.MembrosComunidade.Repositories.Filters;

namespace bookfly.Domain.MembrosComunidade.Services.Interfaces
{
    public interface IMembrosComunidadeService
    {
             Task<MembroComunidade> InserirMembroComunidadeAsync(InserirMembroComunidadeCommand comando, CancellationToken cancellationToken);
        Task<MembroComunidade> EditarMembroComunidadeAsync(EditarMembroComunidadeCommand comando, int id, CancellationToken cancellationToken);
        Task<List<MembroComunidade>> ListarAsync(MembroComunidadeFiltro filtro, CancellationToken cancellationToken);
        Task<MembroComunidade> ValidarAsync(int id, CancellationToken cancellationToken);
        MembroComunidade Instanciar(InserirMembroComunidadeCommand comando);
    }
}