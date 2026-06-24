

using bookfly.Application.Avaliacoes.DataTransfer.Requests;
using bookfly.Application.Avaliacoes.DataTransfer.Responses;

namespace bookfly.Application.Avaliacoes.Services.Interfaces
{
    public interface IAvaliacaoAppService
    {
        Task<IEnumerable<AvaliacaoResponse>> ListarAvaliacoesAsync(ListarAvaliacaoRequest request, CancellationToken cancellationToken);
        Task<AvaliacaoResponse> ObterPorIdAsync(int id, CancellationToken cancellationToken);
        Task<AvaliacaoResponse> InserirAsync(InserirAvaliacaoRequest request, string token, CancellationToken cancellationToken);
        Task<AvaliacaoResponse> EditarAsync(EditarAvaliacaoRequest request, int id, CancellationToken cancellationToken);
        Task ExcluirAsync(int id, CancellationToken cancellationToken);
    }
}
