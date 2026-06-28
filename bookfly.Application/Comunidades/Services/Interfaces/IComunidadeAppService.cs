
using bookfly.Application.Comunidades.DataTransfer.Requests;
using bookfly.Application.Comunidades.DataTransfer.Responses;

namespace bookfly.Application.Comunidades.Services.Interfaces
{
    public interface IComunidadeAppService
    {
        Task<ComunidadeResponse> InserirAsync(ComunidadeInserirRequest request, CancellationToken cancellationToken);
        Task<ComunidadeResponse> EditarAsync(int id, ComunidadeEditarRequest request, CancellationToken cancellationToken);
        Task<List<ComunidadeResponse>> ListarAsync(ComunidadeListarRequest request, CancellationToken cancellationToken);
        Task MudarSituacaoAsync(int id, CancellationToken cancellationToken);
        Task<ComunidadeResponse> RecuperarAsync(int id, CancellationToken cancellationToken);
    }
}