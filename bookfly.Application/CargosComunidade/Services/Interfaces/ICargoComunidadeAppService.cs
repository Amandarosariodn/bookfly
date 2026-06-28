using bookfly.Application.CargosComunidade.DataTransfer.Requests;
using bookfly.Application.CargosComunidade.DataTransfer.Responses;

namespace bookfly.Application.CargosComunidade.Services.Interfaces
{
    public interface ICargoComunidadeAppService
    {
        Task<CargoComunidadeResponse> InserirAsync(InserirCargoComunidadeRequest request, CancellationToken cancellationToken);
        Task<CargoComunidadeResponse> EditarAsync(int id, EditarCargoComunidadeRequest request, CancellationToken cancellationToken);
        Task<List<CargoComunidadeResponse>> ListarAsync(ListarCargoComunidadeRequest request, CancellationToken cancellationToken);
        Task<CargoComunidadeResponse> RecuperarAsync(int id, CancellationToken cancellationToken);
    }
}
