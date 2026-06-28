using bookfly.Domain.Comunidades.Entities;
using bookfly.Domain.Comunidades.Repositories.Filters;
using bookfly.Domain.Comunidades.Repositories.Interfaces;
using NHibernate;
using NHibernate.Linq;

namespace bookfly.Infra.Comunidades
{
    public class ComunidadeRepository(ISession session) : IComunidadeRepository
    {
        public async Task EditarAsync(Comunidade comunidade, CancellationToken cancellationToken)
        {
            if (comunidade == null)
                throw new ArgumentNullException(nameof(comunidade));
            await session.UpdateAsync(comunidade, cancellationToken);
        }

        public IQueryable<Comunidade> Filtrar()
        {
            return session.Query<Comunidade>();

        }

        public async Task InserirAsync(Comunidade comunidade, CancellationToken cancellationToken)
        {
            if (comunidade == null)
                throw new ArgumentNullException(nameof(comunidade));
            await session.SaveAsync(comunidade, cancellationToken);
        }

        public async Task<List<Comunidade>> ListarAsync(ComunidadeFiltro comunidade, CancellationToken cancellationToken)
        {
            var query = session.Query<Comunidade>();

            if (!string.IsNullOrEmpty(comunidade.Nome))
                query = query.Where(c => c.Nome.Contains(comunidade.Nome));

            return await query.ToListAsync(cancellationToken);
        }

        public async Task<Comunidade?> RecuperarPorIdAsync(int comunidadeId, CancellationToken cancellationToken)
        {
            return await session.GetAsync<Comunidade>(comunidadeId, cancellationToken);
        }
    }
}