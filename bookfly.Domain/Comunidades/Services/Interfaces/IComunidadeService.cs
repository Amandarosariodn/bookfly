using bookfly.Domain.Comunidades.Commands;
using bookfly.Domain.Comunidades.Entities;
using bookfly.Domain.Comunidades.Repositories.Filters;

namespace bookfly.Domain.Comunidades.Services.Interfaces
{
    public interface IComunidadeService
    {
        Task<Comunidade> InserirComunidadeAsync(ComunidadeInserirCommand comando, CancellationToken cancellationToken);
        Task<Comunidade> ValidarAsync(int id, CancellationToken cancellationToken);

        Task<Comunidade> EditarComunidadeAsync(ComunidadeEditarCommand comando, int id, CancellationToken cancellationToken);
        Comunidade Instanciar(ComunidadeInserirCommand comando);
        Task MudarSituacaoAsync(int id, CancellationToken cancellationToken);

        Task<List<Comunidade>> ListarAsync(ComunidadeFiltro filtro, CancellationToken cancellationToken);
    }
}