using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using bookfly.Domain.SeguidorUsuarios.Entities;
using bookfly.Domain.SeguidorUsuarios.Repositories;
using NHibernate;

namespace bookfly.Infra.SeguidorUsuarios.Repositories
{
    public class SeguidorUsuarioRepository(ISession session) : ISeguidorUsuarioRepository
    {
        private readonly ISession _session = session;

        public Task<int> ContarSeguidoresAsync(int usuarioId, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public Task<int> ContarSeguindoAsync(int usuarioId, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public Task DeixarDeSeguirAsync(int seguidorId, int seguindoId, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public Task<bool> JaSeguindoAsync(int seguidorId, int seguindoId, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public Task<IReadOnlyList<int>> ObterSeguidoresAsync(int usuarioId, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public Task<IReadOnlyList<int>> ObterSeguindoAsync(int usuarioId, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public Task SeguirAsync(SeguidorUsuario seguidor, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}