

using bookfly.Domain.Metas.Entities;
using bookfly.Domain.Metas.Repositories;
using NHibernate;
using NHibernate.Linq;

namespace bookfly.Infra.Metas
{
    public class MetaRepository(ISession session) : IMetaRepository
    {
        public async Task EditarAsync(Meta meta, CancellationToken cancellationToken)
        {
            if (meta == null)
                throw new ArgumentNullException(nameof(meta));
            await session.UpdateAsync(meta, cancellationToken);
        }

        public async Task<bool?> ExisteMeta(int usuarioId, int idMeta, CancellationToken cancellationToken)
        {
            var query = session.Query<Meta>()
                .Where(m => m.UsuarioId == usuarioId && m.Id == idMeta)
                .Select(m => (bool?)true)
                .FirstOrDefaultAsync(cancellationToken);

                return await query;
        }

        public async Task InserirAsync(Meta meta, CancellationToken cancellationToken)
        {
            if (meta == null)
                throw new ArgumentNullException(nameof(meta));
            await session.SaveAsync(meta, cancellationToken);
        }


        

        public async Task<Meta?> RecuperarPorIdAsync(int id, CancellationToken cancellationToken)
        {
            return await session.GetAsync<Meta>(id, cancellationToken);
        }

        public async Task<Meta> ValidarAsync(int metaId, CancellationToken cancellationToken)
        {
            var meta = await RecuperarPorIdAsync(metaId, cancellationToken);
            if (meta == null)
                throw new Exception("Meta não encontrada");
            return meta;
        }
    }
}