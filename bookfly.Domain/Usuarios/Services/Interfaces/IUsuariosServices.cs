


using bookfly.Domain.Usuarios.Commands;
using bookfly.Domain.Usuarios.Entities;

namespace bookfly.Domain.Usuarios.Services.Interfaces
{
    public interface IUsuariosServices
    {
        
        Task<Usuario> InserirAsync(InserirUsuarioCommand comando, CancellationToken cancellationToken);
        Task<Usuario> EditarAsync(EditarUsuarioCommand comando, CancellationToken cancellationToken);
        Task<List<Usuario>> ListarAsync(ListarUsuarioCommand comando, CancellationToken cancellationToken);
        Task<Usuario> MudarSituacaoAsync(int id, CancellationToken cancellationToken);
    }
}