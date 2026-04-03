
using bookfly.Domain.Categorias.Entities;

namespace bookfly.Domain.Categorias.Repositories
{
    public interface ICategoriasRepository
    {

        // IQueryable<Categoria> Filtrar();
        Task<Categoria?> RecuperarPorId(int categoriaId, CancellationToken cancellationToken);

        Task InserirAsync(Categoria categoria, CancellationToken cancellationToken);
        Task AtualizarAsync(Categoria categoria, CancellationToken cancellationToken);




    }
}