
using bookfly.Domain.MembrosComunidade.Entities;
using bookfly.Domain.MembrosComunidade.Repositories;
using bookfly.Domain.MembrosComunidade.Repositories.Filters;
using NHibernate;
using NHibernate.Linq;

namespace bookfly.Infra.MembrosComunidade
{
    public class MembroComunidadeRepository(ISession session) : IMembrosComunidadeRepository
    {
        public async Task EditarAsync(MembroComunidade membroComunidade, CancellationToken cancellationToken)
        {
            if (membroComunidade == null)
                throw new ArgumentNullException(nameof(membroComunidade));

            await session.UpdateAsync(membroComunidade, cancellationToken);
        }

        public IQueryable<MembroComunidade> Filtrar()
        {
            return session.Query<MembroComunidade>();

        }

        public async Task InserirAsync(MembroComunidade membroComunidade, CancellationToken cancellationToken)
        {
              if (membroComunidade == null)
                throw new ArgumentNullException(nameof(membroComunidade));

            await session.SaveAsync(membroComunidade, cancellationToken);
        }

        public async Task<List<MembroComunidade>> ListarAsync(MembroComunidadeFiltro filtro, CancellationToken cancellationToken)
        {
            var query = session.Query<MembroComunidade>();

            if (filtro.ComunidadeId.HasValue)
                query = query.Where(c => c.ComunidadeId == filtro.ComunidadeId.Value);

            if (filtro.CargoId.HasValue)
                query = query.Where(c => c.CargoId == filtro.CargoId);
            if (filtro.Banido.HasValue)
                query = query.Where(c => c.Banido == filtro.Banido);

            return await query.ToListAsync(cancellationToken);
        }

        public async Task<MembroComunidade?> RecuperarPorIdAsync(int id, CancellationToken cancellationToken)
        {
             return await session.GetAsync<MembroComunidade>(id, cancellationToken);
        }
    }
}