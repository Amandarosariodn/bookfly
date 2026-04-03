
using bookfly.Domain.Categorias.Entities;

namespace bookfly.Domain.Categorias.Repositories
{
    public interface ICategoriasRepository
    {

        IQueryable<Categoria> Filtrar();
        Task InserirAsync(Categoria categoria, CancellationToken cancellationToken);
        Task EditarAsync(Categoria categoria, CancellationToken cancellationToken);
        Task<Categoria?> RecuperarPorIdAsync(int categoriaId, CancellationToken cancellationToken);


    }
}