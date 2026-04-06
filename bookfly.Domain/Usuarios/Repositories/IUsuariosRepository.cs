
using bookfly.Domain.Usuarios.Commands;
using bookfly.Domain.Usuarios.Entities;
using bookfly.Domain.Usuarios.Repositories.Filters;

namespace bookfly.Domain.Usuarios.Repositories
{
    public interface IUsuariosRepository
    {
        Task InserirAsync(Usuario usuario, CancellationToken cancellationToken);
        Task EditarAsync(Usuario usuario, CancellationToken cancellationToken);
        Task<List<Usuario>> ListarAsync(UsuarioFiltro filtro, CancellationToken cancellationToken);
        Task<Usuario> ValidarAsync(int usuarioId, CancellationToken cancellationToken);

    }
}