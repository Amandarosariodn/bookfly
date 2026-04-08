using System.Runtime.InteropServices;
using bookfly.Domain.SeguidorUsuarios.Entities;
using bookfly.Domain.SeguidorUsuarios.Repositories;
using bookfly.Domain.SeguidorUsuarios.Services.Interfaces;

namespace bookfly.Domain.SeguidorUsuarios.Services
{
    public class SeguidorUsuariosService(ISeguidorUsuarioRepository seguidorUsuarioRepository) : ISeguidorUsuariosService
    {
        public async Task DeixarDeSeguirAsync(int seguidorId, int seguidoId, CancellationToken cancellationToken)
        {
            await seguidorUsuarioRepository.DeixarDeSeguirAsync(seguidorId, seguidoId, cancellationToken);


        }

        public async Task<bool> JaSeguindoAsync(int seguidorId, int seguidoId, CancellationToken cancellationToken)
        {
            return await seguidorUsuarioRepository.JaSeguindoAsync(seguidorId, seguidoId, cancellationToken);
        }

        // public Task<List<SeguidorUsuario>> ListarSeguidoresAsync(CancellationToken cancellationToken)
        // {
        //     throw new NotImplementedException();
        // }

        public async Task<List<SeguidorUsuario>> ObterSeguidoresAsync(int usuarioId, CancellationToken cancellationToken)
        {
            return await seguidorUsuarioRepository.ObterSeguidoresAsync(usuarioId, cancellationToken); 

        }

        public async Task<List<SeguidorUsuario>> ObterSeguindoAsync(int usuarioId, CancellationToken cancellationToken)
        {
            var seguindo = await seguidorUsuarioRepository.ObterSeguindoAsync(usuarioId, cancellationToken);

            if (seguindo == null || !seguindo.Any())
                throw new Exception("Você não segue ninguém");

            return seguindo;
        }

        public async Task SeguirAsync(int seguidorId, int seguidoId, CancellationToken cancellationToken)
        {
            await seguidorUsuarioRepository.SeguirAsync(seguidorId, seguidoId, cancellationToken);
        }
    }
}