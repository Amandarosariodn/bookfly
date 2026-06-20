

using bookfly.Application.Avaliacoes.DataTransfer.Requests;
using bookfly.Application.Avaliacoes.DataTransfer.Responses;
using bookfly.Domain.Avaliacoes.Repositories.Filters;

namespace bookfly.Application.Avaliacoes.Services.Interfaces
{
    public interface IAvaliacaoAppService
    {
        Task<IEnumerable<AvaliacaoResponse>> ListarAvaliacoesAsync(AvaliacaoFiltro filtro, CancellationToken cancellationToken);
        Task<AvaliacaoResponse> ObterPorIdAsync(int id, CancellationToken cancellationToken);
        Task<AvaliacaoResponse> InserirAsync(InserirAvaliacaoRequest request, CancellationToken cancellationToken);
        Task<AvaliacaoResponse> EditarAsync(EditarAvaliacaoRequest request, int id, CancellationToken cancellationToken);
        Task ExcluirAsync(int id, CancellationToken cancellationToken);
        
    }
}