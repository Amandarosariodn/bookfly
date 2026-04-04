

using bookfly.Domain.Categorias.Entities;
using bookfly.Domain.Categorias.Repositories;
using bookfly.Domain.Categorias.Repositories.Filters;
using NHibernate;
using NHibernate.Linq;


namespace bookfly.Infra.Categorias.Repositories
{
    public class CategoriaRepository : ICategoriasRepository
    {

        private readonly ISession _session;

        public CategoriaRepository(ISession session)
        {
            _session = session;
        }

        public async Task EditarAsync(Categoria categoria, CancellationToken cancellationToken)
        {

            if (categoria == null)
                throw new ArgumentNullException(nameof(categoria));

            await _session.UpdateAsync(categoria, cancellationToken);

        }

        public IQueryable<Categoria> Filtrar()
        {
            return _session.Query<Categoria>();
        }

        public async Task InserirAsync(Categoria categoria, CancellationToken cancellationToken)
        {
            if (categoria == null)
                throw new ArgumentNullException(nameof(categoria));

            await _session.SaveAsync(categoria, cancellationToken);
        }

        public async Task<List<Categoria>> ListarAsync(CategoriaFiltro categoria, CancellationToken cancellationToken)
        {

            var query = _session.Query<Categoria>();


            if (!string.IsNullOrEmpty(categoria.Nome))
                query = query.Where(c => c.Nome.Contains(categoria.Nome));

            return await query.ToListAsync(cancellationToken);
        }

        public async Task<Categoria?> RecuperarPorIdAsync(int categoriaId, CancellationToken cancellationToken)
        {

            return await _session.GetAsync<Categoria>(
                            categoriaId,
                            cancellationToken);

        }
    }
}