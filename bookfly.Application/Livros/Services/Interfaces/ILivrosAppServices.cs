

using bookfly.Application.Livros.DataTransfer.Requests;
using bookfly.Application.Livros.DataTransfer.Responses;

namespace bookfly.Application.Livros.Services.Interfaces
{
    public interface ILivrosAppServices
    {
        Task<LivroResponse> InserirAsync(InserirLivroRequest request, CancellationToken cancellationToken);
        Task<LivroResponse> EditarAsync(int id, EditarLivroRequest request, CancellationToken cancellationToken);
        Task<LivroResponse> RecuperarAsync(int id, CancellationToken cancellationToken);
        Task<List<LivroResponse>> ListarAsync(ListarLivroRequest request, CancellationToken cancellationToken);
        Task MudarSituacaoAsync(int id, CancellationToken cancellationToken);
        
    }
}