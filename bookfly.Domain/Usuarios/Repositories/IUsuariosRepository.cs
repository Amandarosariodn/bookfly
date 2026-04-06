
using bookfly.Domain.Usuarios.Commands;
using bookfly.Domain.Usuarios.Entities;
using bookfly.Domain.Usuarios.Repositories.Filters;

namespace bookfly.Domain.Usuarios.Repositories
{
    public interface IUsuariosRepository
    {
        Task<Usuario> InserirAsync(InserirUsuarioCommand comando, CancellationToken cancellationToken);
        Task<Usuario> EditarAsync(EditarUsuarioCommand comando, CancellationToken cancellationToken);
        Task<List<Usuario>> ListarAsync(UsuarioFiltro filtro, CancellationToken cancellationToken);
        Task<Usuario> MudarSituacaoAsync(int id, CancellationToken cancellationToken);

    }
}