using bookfly.Domain.Usuarios.Commands;
using bookfly.Domain.Usuarios.Entities;
using bookfly.Domain.Usuarios.Services.Interfaces;

namespace bookfly.Domain.Usuarios.Services
{
    public class UsuariosService : IUsuariosServices
    {
        public Task<Usuario> EditarAsync(EditarUsuarioCommand comando, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public Task<Usuario> InserirAsync(InserirUsuarioCommand comando, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public Task<List<Usuario>> ListarAsync(ListarUsuarioCommand comando, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public Task<Usuario> MudarSituacaoAsync(int id, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        private static Usuario Instanciar(Usuario usuario)
        {
            return new Usuario(usuario.Id, usuario.Email, usuario.Username, usuario.SenhaHash, usuario.Biografia,usuario.UrlImagem, usuario.ReceberSpoilers, usuario.CriadoEm);
        }
    }
}