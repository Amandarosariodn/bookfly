using bookfly.Application.Estantes.DataTransfer.Requests;
using bookfly.Application.Estantes.DataTransfer.Responses;

namespace bookfly.Application.Estantes.Services.Interfaces
{
    public interface IEstantesAppService
    {
        Task<EstanteResponse> InserirAsync(InserirEstanteRequest request, CancellationToken cancellationToken);
        Task<EstanteResponse> EditarAsync(int id, EditarEstanteRequest request, CancellationToken cancellationToken);
        Task<List<EstanteResponse>> ListarAsync(ListarEstanteRequest request, CancellationToken cancellationToken);
        Task MudarSituacaoAsync(int id, CancellationToken cancellationToken);
        Task<EstanteResponse> RecuperarAsync(int id, CancellationToken cancellationToken);
    }
}
