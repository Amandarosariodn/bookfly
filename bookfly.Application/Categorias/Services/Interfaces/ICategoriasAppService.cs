

using bookfly.Application.Categorias.DataTransfer.Requests;
using bookfly.Application.Categorias.DataTransfer.Responses;

namespace bookfly.Application.Categorias.Services.Interfaces
{
    public interface ICategoriasAppService
    {
        Task MudarSituacaoAsync(int id, CancellationToken cancellationToken);
        Task<CategoriaResponse> EditarAsync(int id, EditarCategoriaRequest request, CancellationToken cancellationToken);
        Task<CategoriaResponse> RecuperarAsync(int id, CancellationToken cancellationToken);
        Task<CategoriaResponse> InserirAsync(InserirCategoriaRequest request, CancellationToken cancellationToken);
        Task<List<CategoriaResponse>> ListarAsync(ListarCategoriaRequest request, CancellationToken cancellationToken);
            }
}