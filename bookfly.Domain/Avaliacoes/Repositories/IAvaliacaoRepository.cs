
using bookfly.Domain.Avaliacoes.Entities;
using bookfly.Domain.Avaliacoes.Repositories.Filters;

namespace bookfly.Domain.Avaliacoes.Repositories
{
    public interface IAvaliacaoRepository
    {
        Task<Avaliacao?> ObterPorIdAsync(int id, CancellationToken cancellationToken);
        Task<IEnumerable<Avaliacao>> ListarAvaliacoesAsync(AvaliacaoFiltro filtro, CancellationToken cancellationToken);
        Task InserirAsync(Avaliacao avaliacao, CancellationToken cancellationToken);
        Task EditarAsync(Avaliacao avaliacao, CancellationToken cancellationToken);
        Task AtualizarAsync(Avaliacao avaliacao, CancellationToken cancellationToken);
        Task ExcluirAsync(Avaliacao avaliacao, CancellationToken cancellationToken);
    }
}