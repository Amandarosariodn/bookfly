using bookfly.Domain.Enums;
using bookfly.Domain.Usuarios.Commands;
using bookfly.Domain.Usuarios.Entities;
using bookfly.Domain.Usuarios.Repositories;
using bookfly.Domain.Usuarios.Services.Interfaces;

namespace bookfly.Domain.Usuarios.Services
{
    public class UsuariosService(IUsuariosRepository usuariosRepository) : IUsuariosServices
    {
        public async Task<Usuario> EditarAsync(EditarUsuarioCommand comando,int id, CancellationToken cancellationToken)
        {
            Usuario usuario = await ValidarAsync(id, cancellationToken);

            usuario.SetEmail(comando.Email);
            usuario.SetUsername(comando.Username);
            usuario.SetSenhaHash(comando.SenhaHash);
            usuario.SetBiografia(comando.Biografia);
            usuario.SetUrlImagem(comando.UrlImagem);
            usuario.SetReceberSpoilers(comando.ReceberSpoilers);
            usuario.SetSituacao(comando.Situacao);
            usuario.SetCriadoEm(comando.CriadoEm);

            await usuariosRepository.EditarAsync(comando, cancellationToken);
            return usuario;
            
        }

        public async Task<Usuario> InserirAsync(InserirUsuarioCommand comando, CancellationToken cancellationToken)
        {
            Usuario usuario = Instanciar(comando);

            await usuariosRepository.InserirAsync(comando, cancellationToken);
            return usuario;
        }

        public async Task<List<Usuario>> ListarAsync(ListarUsuarioCommand filtro, CancellationToken cancellationToken)
        {
            var usuarios = await usuariosRepository.ListarAsync(filtro, cancellationToken);

            if(usuarios == null || !usuarios.Any())
                return new List<Usuario>();

            return usuarios ?? new List<Usuario>();
        }

        public async Task MudarSituacaoAsync(int id, CancellationToken cancellationToken)
        {
            Usuario usuario = await ValidarAsync(id, cancellationToken);

            switch (usuario.Situacao)
            {
                case AtivoInativoEnum.Ativo:
                    usuario.SetSituacao(AtivoInativoEnum.Inativo);
                    break;
                case AtivoInativoEnum.Inativo: usuario.SetSituacao(AtivoInativoEnum.Ativo); break;
            }
        }

        private static Usuario Instanciar(InserirUsuarioCommand usuario)
        {
            return new Usuario(usuario.Email, usuario.Username, usuario.SenhaHash, usuario.Biografia, usuario.UrlImagem, usuario.ReceberSpoilers, usuario.CriadoEm);
        }

        public async Task<Usuario> ValidarAsync(int usuarioId, CancellationToken cancellationToken)
        {
            Usuario usuario = await usuariosRepository.ValidarAsync(usuarioId, cancellationToken);

            if (usuario == null)
                throw new Exception("Usuário não encontrado");

            return usuario;
        }
    }
}