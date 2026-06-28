using bookfly.Domain.CargosComunidade.Entities;
using bookfly.Domain.CargosComunidade.Repositories.Filters;
using bookfly.Domain.CargosComunidade.Repositories.Interfaces;
using NHibernate;
using NHibernate.Linq;

namespace bookfly.Infra.CargosComunidade.Repositories
{
    public class CargoComunidadeRepository(ISession session) : ICargoComunidadeRepository
    {
        public async Task EditarAsync(CargoComunidade cargoComunidade, CancellationToken cancellationToken)
        {
            if (cargoComunidade == null)
                throw new ArgumentNullException(nameof(cargoComunidade));

            await session.UpdateAsync(cargoComunidade, cancellationToken);
        }

        public IQueryable<CargoComunidade> Filtrar()
        {
            return session.Query<CargoComunidade>();
        }

        public async Task InserirAsync(CargoComunidade cargoComunidade, CancellationToken cancellationToken)
        {
            if (cargoComunidade == null)
                throw new ArgumentNullException(nameof(cargoComunidade));

            await session.SaveAsync(cargoComunidade, cancellationToken);
        }

        public async Task<List<CargoComunidade>> ListarAsync(CargoComunidadeFiltro filtro, CancellationToken cancellationToken)
        {
            var query = session.Query<CargoComunidade>();

            if (filtro.ComunidadeId.HasValue)
                query = query.Where(c => c.ComunidadeId == filtro.ComunidadeId.Value);

            if (!string.IsNullOrWhiteSpace(filtro.Nome))
                query = query.Where(c => c.Nome.Contains(filtro.Nome));

            return await query.ToListAsync(cancellationToken);
        }

        public async Task<CargoComunidade?> RecuperarPorIdAsync(int id, CancellationToken cancellationToken)
        {
            return await session.GetAsync<CargoComunidade>(id, cancellationToken);
        }
    }
}
