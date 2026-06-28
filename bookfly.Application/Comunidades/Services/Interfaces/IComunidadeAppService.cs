
using bookfly.Application.Comunidades.DataTransfer.Requests;
using bookfly.Application.Comunidades.DataTransfer.Responses;

namespace bookfly.Application.Comunidades.Services.Interfaces
{
    public interface IComunidadeAppService
    {
        Task<ComunidadeResponseDto> InserirAsync(ComunidadeInserirRequest request, CancellationToken cancellationToken);
        Task<ComunidadeResponseDto> EditarAsync(int id, ComunidadeEditarRequest request, CancellationToken cancellationToken);
        Task<List<ComunidadeResponseDto>> ListarAsync(ComunidadeListarRequest request, CancellationToken cancellationToken);
        Task MudarSituacaoAsync(int id, CancellationToken cancellationToken);
        Task<ComunidadeResponseDto> RecuperarAsync(int id, CancellationToken cancellationToken);
    }
}