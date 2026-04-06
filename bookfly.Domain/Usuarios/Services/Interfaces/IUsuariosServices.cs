


using bookfly.Domain.Usuarios.Commands;
using bookfly.Domain.Usuarios.Entities;
using bookfly.Domain.Usuarios.Repositories.Filters;

namespace bookfly.Domain.Usuarios.Services.Interfaces
{
    public interface IUsuariosServices
    {
        
        Task<Usuario> InserirAsync(InserirUsuarioCommand comando, CancellationToken cancellationToken);
        Task<Usuario> EditarAsync(EditarUsuarioCommand comando, int id, CancellationToken cancellationToken);
        Task<List<Usuario>> ListarAsync(UsuarioFiltro filtro, CancellationToken cancellationToken);
        Task MudarSituacaoAsync(int id, CancellationToken cancellationToken);
        Task<Usuario> ValidarAsync(int usuarioId, CancellationToken cancellationToken);
    }
}