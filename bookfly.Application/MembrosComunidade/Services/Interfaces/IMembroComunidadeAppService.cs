using bookfly.Application.MembrosComunidade.DataTransfer.Requests;
using bookfly.Application.MembrosComunidade.DataTransfer.Responses;

namespace bookfly.Application.MembrosComunidade.Services.Interfaces
{
    public interface IMembroComunidadeAppService
    {
        Task<MembroComunidadeResponse> InserirAsync(InserirMembroComunidadeRequest request, CancellationToken cancellationToken);
        Task<MembroComunidadeResponse> EditarAsync(int id, EditarMembroComunidadeRequest request, CancellationToken cancellationToken);
        Task<List<MembroComunidadeResponse>> ListarAsync(ListarMembroComunidadeRequest request, CancellationToken cancellationToken);
        Task<MembroComunidadeResponse> RecuperarAsync(int id, CancellationToken cancellationToken);
    }
}