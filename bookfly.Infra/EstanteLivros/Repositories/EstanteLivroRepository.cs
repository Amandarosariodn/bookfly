using bookfly.Domain.EstanteLivros.Entities;
using bookfly.Domain.EstanteLivros.Repositories.Filters;
using bookfly.Domain.EstanteLivros.Repositories.Interfaces;
using NHibernate;
using NHibernate.Linq;

namespace bookfly.Infra.EstanteLivros.Repositories
{
    public class EstanteLivroRepository(ISession session) : IEstanteLivrosRepository
    {
        private readonly ISession _session = session;

        public async Task EditarAsync(EstanteLivro estanteLivro, CancellationToken cancellationToken)
        {
            if (estanteLivro == null)
                throw new ArgumentNullException(nameof(estanteLivro));
            await _session.UpdateAsync(estanteLivro, cancellationToken);
        }

        public IQueryable<EstanteLivro> Filtrar()
        {
            return _session.Query<EstanteLivro>();
        }
        public async Task InserirAsync(EstanteLivro estanteLivro, CancellationToken cancellationToken)
        {
            if (estanteLivro == null)
                throw new ArgumentNullException(nameof(estanteLivro));
            await _session.SaveAsync(estanteLivro, cancellationToken);

        }
        
        public async Task<List<EstanteLivro>> ListarAsync(EstanteLivroFiltro estanteLivro, CancellationToken cancellationToken)
        {
            var query = _session.Query<EstanteLivro>();

            if(estanteLivro.EstanteId.HasValue)
                query = query.Where(e => e.Estante.Id == estanteLivro.EstanteId.Value);
            
            if(estanteLivro.LivroId.HasValue)
                query = query.Where(e => e.Livro.Id == estanteLivro.LivroId.Value);
            
            if(estanteLivro.Ativo.HasValue)
                query = query.Where(e => e.Ativo == estanteLivro.Ativo.Value);

            if(estanteLivro.StatusLeitura.HasValue)
                query = query.Where(e => e.StatusLeitura == estanteLivro.StatusLeitura.Value);
            
            return await query.ToListAsync(cancellationToken);
        }

        public async Task<EstanteLivro?> RecuperarPorIdAsync(int estanteLivroId, CancellationToken cancellationToken)
        {
            return await _session.GetAsync<EstanteLivro>(estanteLivroId, cancellationToken);
        }

        
        
    }
}
