using bookfly.Application.EstanteLivros.DataTransfer.Requests;
using bookfly.Application.EstanteLivros.DataTransfer.Responses;

namespace bookfly.Application.EstanteLivros.Services.Interfaces
{
    public interface IEstanteLivrosAppServices
    {
        Task<EstanteLivroResponse?> ValidarAsync(int livroId, CancellationToken cancellationToken);
        Task<EstanteLivroResponse> RecuperarAsync(int id, CancellationToken cancellationToken);
        Task<EstanteLivroResponse> InserirEstanteLivroAsync(InserirEstanteLivroRequest request, CancellationToken cancellationToken);
        Task<EstanteLivroResponse> EditarEstanteLivroAsync(EditarEstanteLivroRequest request, int id, CancellationToken cancellationToken);
        Task<List<EstanteLivroResponse>> ListarAsync(ListarEstanteLivroRequest request, CancellationToken cancellationToken);
    }
}
