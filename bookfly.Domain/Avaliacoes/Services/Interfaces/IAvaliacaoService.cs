
using bookfly.Domain.Avaliacoes.Commands;
using bookfly.Domain.Avaliacoes.Entities;
using bookfly.Domain.Avaliacoes.Repositories.Filters;

namespace bookfly.Domain.Avaliacoes.Services.Interfaces
{
    public interface IAvaliacaoService
    {
        Task<Avaliacao?> ObterPorIdAsync(int id, CancellationToken cancellationToken);
        Task<List<Avaliacao>> ListarAvaliacoesAsync(AvaliacaoFiltro filtro, CancellationToken cancellationToken);
        Task<Avaliacao> InserirAsync(InserirAvaliacaoCommand comando, CancellationToken cancellationToken);
        Task<Avaliacao> EditarAsync(EditarAvaliacaoCommand comando, int id, CancellationToken cancellationToken);
        Task ExcluirAsync(Avaliacao avaliacao, CancellationToken cancellationToken);
    }
}