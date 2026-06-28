using bookfly.Domain.Posts.Commands;
using bookfly.Domain.Posts.Entities;
using bookfly.Domain.Posts.Repositories.Filters;

namespace bookfly.Domain.Posts.Services.Interfaces
{
    public interface IPostService
    {
        Task<Post> InserirPostAsync(InserirPostCommand comando, CancellationToken cancellationToken);
        Task<Post> EditarPostAsync(EditarPostCommand comando, long id, CancellationToken cancellationToken);
        Task<List<Post>> ListarAsync(PostFiltro filtro, CancellationToken cancellationToken);
        Task<Post> ValidarAsync(long id, CancellationToken cancellationToken);
        Post Instanciar(InserirPostCommand comando);
    }
}