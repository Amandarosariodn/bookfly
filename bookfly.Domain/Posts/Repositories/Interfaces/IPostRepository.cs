using bookfly.Domain.Posts.Entities;
using bookfly.Domain.Posts.Repositories.Filters;

namespace bookfly.Domain.Posts.Repositories.Interfaces
{
    public interface IPostRepository
    {
        IQueryable<Post> Filtrar();
        Task InserirAsync(Post post, CancellationToken cancellationToken);
        Task EditarAsync(Post post, CancellationToken cancellationToken);
        Task<Post?> RecuperarPorIdAsync(long postId, CancellationToken cancellationToken);
        Task<List<Post>> ListarAsync(PostFiltro filtro, CancellationToken cancellationToken);
    }
}