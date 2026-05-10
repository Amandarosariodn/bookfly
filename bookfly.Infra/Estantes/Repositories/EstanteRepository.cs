using System.Runtime.InteropServices;
using System.Threading.Tasks;
using bookfly.Domain.Estantes.Entities;
using bookfly.Domain.Estantes.Repositories.Filters;
using bookfly.Domain.Estantes.Repositories.Interfaces;
using NHibernate;
using NHibernate.Linq;

namespace bookfly.Infra.Estantes.Repositories
{
    public class EstanteRepository(ISession session) : IEstanteRepository
    {
        private readonly ISession _session = session;
        public async Task EditarAsync(Estante estante, CancellationToken cancellationToken)
        {
            if (estante == null)
                throw new ArgumentNullException(nameof(estante));
            await _session.UpdateAsync(estante, cancellationToken);
        }

        public IQueryable<Estante> Filtrar()
        {
            return _session.Query<Estante>();
        }

        public async Task InserirAsync(Estante estante, CancellationToken cancellationToken)
        {
            if (estante == null)
                throw new ArgumentNullException(nameof(estante));
            await _session.SaveAsync(estante, cancellationToken);

        }

        public async Task<List<Estante>> ListarAsync(EstanteFiltro estante, CancellationToken cancellationToken)
        {
            var query = _session.Query<Estante>();

            if(!string.IsNullOrEmpty(estante.Nome))
                query = query.Where(e => e.Nome.Contains(estante.Nome));
            
            return await query.ToListAsync(cancellationToken);
        }

        public async Task<Estante?> RecuperarPorIdAsync(int estanteId, CancellationToken cancellationToken)
        {
            return await _session.GetAsync<Estante>(estanteId, cancellationToken);
        }
    }
}