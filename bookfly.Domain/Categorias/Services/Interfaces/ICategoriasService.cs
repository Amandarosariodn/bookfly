using bookfly.Domain.Categorias.Commands;
using bookfly.Domain.Categorias.Entities;
using bookfly.Domain.Categorias.Repositories.Filters;

namespace bookfly.Domain.Categorias.Services.Interfaces
{
    public interface ICategoriasService
    {
        Task<Categoria> InserirCategoriaAsync(InserirCategoriaCommand comando, CancellationToken cancellationToken);
        Task<Categoria> ValidarAsync(int id, CancellationToken cancellationToken);

        Task<Categoria> EditarCategoriaAsync(EditarCategoriaCommand comando, int id, CancellationToken cancellationToken);
        Categoria Instanciar(InserirCategoriaCommand comando);
        Task MudarSituacaoAsync(int id, CancellationToken cancellationToken);

        Task<List<Categoria>> ListarAsync(CategoriaFiltro categoria, CancellationToken cancellationToken);
    }
}