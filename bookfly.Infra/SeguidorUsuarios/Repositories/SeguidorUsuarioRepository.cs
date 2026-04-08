using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using bookfly.Domain.SeguidorUsuarios.Entities;
using bookfly.Domain.SeguidorUsuarios.Repositories;
using NHibernate;
using NHibernate.Linq;

namespace bookfly.Infra.SeguidorUsuarios.Repositories
{
    public class SeguidorUsuarioRepository(ISession session) : ISeguidorUsuarioRepository
    {
        private readonly ISession _session = session;

        public async Task<int> ContarSeguidoresAsync(
        int usuarioId,
        CancellationToken cancellationToken)
        {
            return await _session
                .Query<SeguidorUsuario>()
                .Where(s => s.SeguidorID == usuarioId)
                .CountAsync(cancellationToken);
        }
        public async Task<int> ContarSeguindoAsync(int usuarioId, CancellationToken cancellationToken)
        {
            return await _session.Query<SeguidorUsuario>().Where(s => s.SeguidoID == usuarioId).CountAsync(cancellationToken);
        }

        public async Task DeixarDeSeguirAsync(
        int seguidorId,
        int seguidoId,
        CancellationToken cancellationToken)
        {
            var relacao = await _session
                .Query<SeguidorUsuario>()
                .FirstOrDefaultAsync(
                    s => s.SeguidorID == seguidorId
                      && s.SeguidoID == seguidoId,
                    cancellationToken);

            if (relacao == null)
                throw new Exception("Usuário não está seguindo.");

            await _session.DeleteAsync(
                relacao,
                cancellationToken);
        }

        public async Task<bool> JaSeguindoAsync(
        int seguidorId,
        int seguindoId,
        CancellationToken cancellationToken)
        {
            return await _session
                .Query<SeguidorUsuario>()
                .AnyAsync(
                    s => s.SeguidorID == seguidorId
                      && s.SeguidoID == seguindoId,
                    cancellationToken);
        }

        public async Task<List<SeguidorUsuario>> ObterSeguidoresAsync(
        int usuarioId,
        CancellationToken cancellationToken)
        {
            return await _session
                .Query<SeguidorUsuario>()
                .Where(s => s.SeguidoID == usuarioId)
                .ToListAsync(cancellationToken);
        }

        public async Task<List<SeguidorUsuario>> ObterSeguindoAsync(int usuarioId, CancellationToken cancellationToken)
        {
            return await _session.Query<SeguidorUsuario>().Where(s => s.SeguidorID == usuarioId).ToListAsync(cancellationToken);
        }

        public async Task SeguirAsync(
        int seguidorId,
        int seguidoId,
        CancellationToken cancellationToken)
        {
            if (seguidorId == seguidoId)
                throw new Exception("Usuário não pode seguir a si mesmo.");

            bool jaSegue = await _session
                .Query<SeguidorUsuario>()
                .AnyAsync(
                    s => s.SeguidorID == seguidorId
                      && s.SeguidoID == seguidoId,
                    cancellationToken);

            if (jaSegue)
                throw new Exception("Usuário já está seguindo.");

            var novoSeguidor = new SeguidorUsuario(
                seguidorId,
                seguidoId);

            await _session.SaveAsync(
                novoSeguidor,
                cancellationToken);
        }
    }
}