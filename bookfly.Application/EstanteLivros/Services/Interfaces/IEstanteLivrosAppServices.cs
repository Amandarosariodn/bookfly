using bookfly.Application.EstanteLivros.DataTransfer.Requests;
using bookfly.Application.EstanteLivros.DataTransfer.Responses;

namespace bookfly.Application.EstanteLivros.Services.Interfaces
{
    public interface IEstanteLivrosAppServices
    {
        Task<EstanteLivroResponseDto?> ValidarAsync(int livroId, CancellationToken cancellationToken);
        Task<EstanteLivroResponseDto> RecuperarAsync(int id, CancellationToken cancellationToken);
        Task<EstanteLivroResponseDto> InserirEstanteLivroAsync(InserirEstanteLivroRequest request, CancellationToken cancellationToken);
        Task<EstanteLivroResponseDto> EditarEstanteLivroAsync(EditarEstanteLivroRequest request, int id, CancellationToken cancellationToken);
        Task<List<EstanteLivroResponseDto>> ListarAsync(ListarEstanteLivroRequest request, CancellationToken cancellationToken);
    }
}
