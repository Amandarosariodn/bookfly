using bookfly.Application.Posts.DataTransfer.Requests;
using bookfly.Application.Posts.DataTransfer.Responses;

namespace bookfly.Application.Posts.Services.Interfaces
{
    public interface IPostAppService
    {
        Task<PostResponse> InserirAsync(InserirPostRequest request, CancellationToken cancellationToken);
        Task<PostResponse> EditarAsync(long id, EditarPostRequest request, CancellationToken cancellationToken);
        Task<List<PostResponse>> ListarAsync(ListarPostRequest request, CancellationToken cancellationToken);
        Task<PostResponse> RecuperarAsync(long id, CancellationToken cancellationToken);
    }
}